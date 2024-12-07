using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Security.Cryptography;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using System.IO;

namespace ElGammal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void encryptButton_Click(object sender, EventArgs e)
        {
            // Проверка, чтобы в textBoxP, textBoxX, и textBoxK находились числа
            if (!BigInteger.TryParse(textBoxP.Text, out BigInteger p) || p < 997)
            {
                MessageBox.Show("В поле P должно быть указано простое число больше 997.");
                return;
            }

            if (!BigInteger.TryParse(textBoxX.Text, out BigInteger x) || x <= 1 || x >= p)
            {
                MessageBox.Show("В поле X должно быть указано число в пределах от 1 до P.");
                return;
            }

            if (!BigInteger.TryParse(textBoxK.Text, out BigInteger k) || k <= 1 || k >= p - 1)
            {
                MessageBox.Show("В поле K должно быть указано число в пределах от 1 до P-1.");
                return;
            }

            // Генерация ключей
            var (pGenerated, g, xGenerated, y) = GenerateKeys();
            if (pGenerated == BigInteger.Zero) return; // Если возникла ошибка при генерации ключа

            // Считывание сессионного ключа из поля (k уже проверен выше)
            // Преиспользуем значение p, g, x, y для ключей, если они успешно сгенерированы
            p = pGenerated;
            x = xGenerated;

            // Шифруем сообщение
            string message = textBoxInput.Text;
            var cipherText = EncryptMessage(message, p, g, y, k);

            // Вывод зашифрованного текста
            StringBuilder encryptedMessage = new StringBuilder();
            foreach (var (a, b) in cipherText)
            {
                //encryptedMessage.Append($"({a}, {b}) ");
                encryptedMessage.Append($"({a}, {b}) ");
            }

            textBoxOutput.Text = encryptedMessage.ToString();
        }


        // Функция для вычисления степени по модулю (g^k mod p)
        private BigInteger ModPow(BigInteger baseValue, BigInteger exponent, BigInteger modulus)
        {
            return BigInteger.ModPow(baseValue, exponent, modulus);
        }

        // Функция для нахождения первообразного корня с использованием функции Эйлера
        private BigInteger FindPrimitiveRoot(BigInteger p)
        {
            BigInteger phi = p;  // Функция Эйлера для простого числа p
            List<BigInteger> divisors = GetDivisors(phi);  // Получаем делители phi(p)

            for (BigInteger g = 2; g < p; g++)
            {
                bool isPrimitiveRoot = true;

                // Проверяем, является ли g первообразным корнем
                foreach (BigInteger divisor in divisors)
                {
                    // Проверяем, что g^((phi(p))/divisor) % p != 1
                    if (ModPow(g, phi / divisor, p) == 1)
                    {
                        isPrimitiveRoot = false;
                        break;
                    }
                }

                // Если не нашли нарушений, g является первообразным корнем
                if (isPrimitiveRoot)
                {
                    return g;
                }
            }

            // Если не найдено, возвращаем -1 (ошибка)
            return -1;
        }


        // Функция для нахождения делителей числа n
        private List<BigInteger> GetDivisors(BigInteger n)
        {
            List<BigInteger> divisors = new List<BigInteger>();
            for (BigInteger i = 1; i <= n; i++)
            {
                if (n % i == 0)
                {
                    divisors.Add(i);
                }
            }
            return divisors;
        }

        // Генерация открытого и закрытого ключа
        private (BigInteger p, BigInteger g, BigInteger x, BigInteger y) GenerateKeys()
        {
            BigInteger p = BigInteger.Parse(textBoxP.Text);  // Простое число p

            // Ищем первообразный корень g
            BigInteger g = FindPrimitiveRoot(p);
            if (g == -1)
            {
                MessageBox.Show("Не удалось найти первообразный корень для числа p.");
                return (BigInteger.Zero, BigInteger.Zero, BigInteger.Zero, BigInteger.Zero);
            }

            BigInteger x = BigInteger.Parse(textBoxX.Text);  // Закрытый ключ x

            // Открытый ключ y = (g^x) % p
            BigInteger y = ModPow(g, x, p);

            return (p, g, x, y);
        }

        // Шифрование сообщения по алгоритму Эль-Гамаля
        private List<Tuple<BigInteger, BigInteger>> EncryptMessage(string message, BigInteger p, BigInteger g, BigInteger y, BigInteger k)
        {
            List<Tuple<BigInteger, BigInteger>> cipherText = new List<Tuple<BigInteger, BigInteger>>();

            foreach (char c in message)
            {
                BigInteger M = (BigInteger)c; // Преобразуем символ в число (ASCII код)
                BigInteger a = ModPow(g, k, p);  // a = g^k mod p
                BigInteger b = (ModPow(y, k, p) * M) % p;  // b = (y^k * M) mod p

                cipherText.Add(new Tuple<BigInteger, BigInteger>(a, b));
            }

            return cipherText;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // Открытие диалога выбора файла
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"; // Фильтр для типов файлов
            saveFileDialog.Title = "Сохранить файл";

            // Если пользователь выбрал файл и нажал "Сохранить"
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Получаем путь к файлу
                string filePath = saveFileDialog.FileName;

                try
                {
                    // Сохраняем текст из textBoxOutput в выбранный файл
                    System.IO.File.WriteAllText(filePath, textBoxOutput.Text);
                    MessageBox.Show("Файл успешно сохранен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // В случае ошибки выводим сообщение
                    MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            // Создаем диалог выбора файла
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                Title = "Выберите текстовый файл"
            };

            // Показываем диалог и проверяем, выбрал ли пользователь файл
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Читаем содержимое файла
                    string fileContent = File.ReadAllText(openFileDialog.FileName);

                    // Загружаем текст в текстовое поле
                    textBoxInput.Text = fileContent;
                }
                catch (Exception ex)
                {
                    // Обрабатываем возможные ошибки
                    MessageBox.Show($"Ошибка при чтении файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void decryptButton_Click(object sender, EventArgs e)
        {
            // Проверка, чтобы в textBoxP и textBoxX находились числа
            if (!BigInteger.TryParse(textBoxP.Text, out BigInteger p) || p <= 1)
            {
                MessageBox.Show("В поле P должно быть указано простое число больше 1.");
                return;
            }

            if (!BigInteger.TryParse(textBoxX.Text, out BigInteger x) || x <= 1 || x >= p)
            {
                MessageBox.Show("В поле X должно быть указано число в пределах от 1 до P.");
                return;
            }

            // Считываем зашифрованное сообщение
            string encryptedText = textBoxInput.Text.Trim();
            if (string.IsNullOrWhiteSpace(encryptedText))
            {
                MessageBox.Show("Поле зашифрованного текста не должно быть пустым.");
                return;
            }

            // Разбираем зашифрованное сообщение в список пар (a, b)
            var cipherText = new List<Tuple<BigInteger, BigInteger>>();
            try
            {
                var matches = Regex.Matches(encryptedText, @"\((\d+),\s*(\d+)\)");
                foreach (Match match in matches)
                {
                    if (BigInteger.TryParse(match.Groups[1].Value, out BigInteger a) &&
                        BigInteger.TryParse(match.Groups[2].Value, out BigInteger b))
                    {
                        cipherText.Add(new Tuple<BigInteger, BigInteger>(a, b));
                    }
                    else
                    {
                        throw new Exception("Неверный формат зашифрованного текста.");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Неверный формат зашифрованного текста. Убедитесь, что он состоит из пар чисел в формате (a, b).");
                return;
            }

            // Расшифровываем сообщение
            string decryptedMessage = DecryptMessage(cipherText, p, x);

            // Вывод расшифрованного текста
            textBoxOutput.Text = decryptedMessage;
        }


        // Функция для расшифрования сообщения по алгоритму Эль-Гамаля
        private string DecryptMessage(List<Tuple<BigInteger, BigInteger>> cipherText, BigInteger p, BigInteger x)
        {
            StringBuilder decryptedMessage = new StringBuilder();

            foreach (var (a, b) in cipherText)
            {
                // Вычисляем a^x mod p
                BigInteger ax = ModPow(a, x, p);

                // Вычисляем мультипликативную инверсию a^x mod p
                BigInteger axInverse = ModInverse(ax, p);

                // Восстанавливаем исходное сообщение M = (b * axInverse) % p
                BigInteger M = (b * axInverse) % p;
                if (M < 0 || M > char.MaxValue)
                {
                    throw new Exception($"Расшифрованное значение '{M}' выходит за пределы диапазона символов.");
                }
                decryptedMessage.Append((char)M);


            }

            return decryptedMessage.ToString();
        }

        // Функция для нахождения мультипликативной инверсии
        private BigInteger ModInverse(BigInteger a, BigInteger p)
        {
            return BigInteger.ModPow(a, p - 2, p); // Используем теорему Эйлера для вычисления обратного элемента
        }




    }
}


