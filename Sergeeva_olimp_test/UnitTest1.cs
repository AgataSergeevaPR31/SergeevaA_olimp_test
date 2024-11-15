//меняем на требуемые
using FamiliaI_PR_31_zd_1;
using FamiliaI_PR_31_zd_4;
using FamiliaI_PR_31_zd_6;

//если проверка для 2 пг, то следует законментировать тесты в блоке с заданием 6

namespace Sergeeva_olimp_test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        //ДЛЯ 1 ЗАДАНИЯ
        string expectedNamespace1 = ""; //Меняем на требуемый
        string inputPath1 = @"\input.txt"; //меняем на нужный путь
        string outputPath1 = @"\output.txt"; //меняем на нужный путь

        //ДЛЯ 4 ЗАДАНИЯ
        string expectedNamespace2 = ""; //Меняем на требуемый
        string inputPath2 = @"\input.txt"; //меняем на нужный путь
        string outputPath2 = @"\output.txt"; //меняем на нужный путь


        //ДЛЯ 6 ЗАДАНИЯ
        string expectedNamespace6 = ""; //Меняем на требуемый
        string inputPath6 = @"\input.txt"; //меняем на нужный путь
        string outputPath6 = @"\output.txt"; //меняем на нужный путь



        //
        //HELP METHODS
        //

        //метод-помощник на проверку корректности типа входных данных в файле с входными данными
        private bool ValidateInputFromFile1(string filePath)
        {
            // Читаем содержимое файла
            var input = File.ReadAllText(filePath).Trim();

            // Проверяем, что строка не пустая
            if (string.IsNullOrEmpty(input)) return false;

            // Разделяем строку по пробелам
            var parts = input.Split(' ');

            // Проверяем, что ровно два элемента
            if (parts.Length != 2) return false;

            // Проверяем, что оба элемента - целые числа
            return int.TryParse(parts[0], out _) && int.TryParse(parts[1], out _);
        }

        //метод-помощник на проверку корректности типа результата в файле с результатом
        private bool IsOutputFileValid1(string filePath)
        {
            // Читаем содержимое файла
            var input = File.ReadAllText(filePath).Trim();

            // Проверяем, что строка пустая
            if (string.IsNullOrEmpty(input)) return true; // Пустой файл считается валидным

            // Разделяем строку по пробелам
            var parts = input.Split(' ');

            // Проверяем, что ровно один элемент
            if (parts.Length != 1) return false;

            // Проверяем, что элемент - целое число
            return int.TryParse(parts[0], out _);
        }
        //метод-помощник для создания и заполнения временных фалов
        public string Helper(string inputValue)
        {
            // Создание временных файлов
            string inputFile = Path.GetTempFileName();
            string outputFile = Path.GetTempFileName();
            try
            {
                // Подготовка входных данных
                File.WriteAllText(inputFile, inputValue);
                // Запуск программы
                Program.Main(new string[] { inputFile, outputFile });
                // Чтение результата
                return File.ReadAllText(outputFile).Trim();
            }
            finally
            {
                // Удаление временных файлов
                if (File.Exists(inputFile)) File.Delete(inputFile);
                if (File.Exists(outputFile)) File.Delete(outputFile);
            }
        }

        //ЗАДАНИЕ 1
        //


        //ПРАВИЛЬНОЕ НАЗВАНИЕ NAMESPACE
        [Test]
        public void A1_Namespace()
        {
            string actualNamespace = typeof(Program).Namespace;

            Assert.AreEqual(expectedNamespace1, actualNamespace);
        }

        //НАЛИЧИЕ ФАЙЛА С ВХОДНЫМИ ДАННЫМИ
        [Test]
        public void B1_InputFileExists()
        {
            Assert.IsTrue(File.Exists(inputPath1), $"Файл {inputPath1} не найден.");
        }

        //НАЛИЧИЕ ФАЙЛА ДЛЯ ВЫВОДА РЕЗУЛЬТАТА
        [Test]
        public void C1_OutputFileExists()
        {

            // Проверяем наличие файлов
            Assert.IsTrue(File.Exists(outputPath1), $"Файл {outputPath1} не найден.");
        }

        //КОРРЕКТНОСТЬ ВХОДНЫХ ДАННЫХ
        [Test]
        public void D1_InputFileDate()
        {
            Assert.IsTrue(ValidateInputFromFile1(inputPath1));
        }

        //КОРРРЕКТНОСТЬ ТИПА РЕЗУЛЬТАТА
        [Test]
        public void E1_OutputFileValidation()
        {
            Assert.IsTrue(IsOutputFileValid1(outputPath1), "В файле или пусто или там одно целое число");
        }

        //НОЛЬ РЫБ, ОДИН РЫБАК
        [Test]
        public void F1_ZeroFishOneFishman()
        {
            string result = Helper("1 0");
            Assert.AreEqual("0", result);
        }

        //НОЛЬ РЫБ, МНОГО РЫБАКОВ
        [Test]
        public void G1_ZeroFishManyFishman()
        {
            string result = Helper("50 0");
            Assert.AreEqual("0", result);
        }

        //ОДНА РЫБА, ОДИН РЫБАК
        [Test]
        public void H1_OneFishOneFishman()
        {
            string result = Helper("1 1");
            Assert.AreEqual("1", result);
        }

        //ОДНА РЫБА, МНОГО РЫБАКОВ
        [Test]
        public void I1_OneFishManyFishman()
        {
            string result = Helper("50 1");
            Assert.AreEqual("0", result);
        }

        //МНОГО РЫБЫ, ОДИН РЫБАК
        [Test]
        public void J1_ManyFishOneFishman()
        {
            string result = Helper("1 30");
            Assert.AreEqual("30", result);
        }

        //РЫБ МАЛО И НЕ ХВАТИТ ДАЖЕ ПО ОДНОЙ
        [Test]
        public void K1_FewFishManyFishman()
        {
            string result = Helper("5 3");
            Assert.AreEqual("0", result);
        }

        //ХВАТИТ ПО ОДНОЙ РЫБЕ РОВНО
        [Test]
        public void L1_ExactlyOne()
        {
            string result = Helper("5 5");
            Assert.AreEqual("1", result);
        }

        //ВСЕМ ХВАТАЕТ ПО ОДНОЙ РЫБЕ, НО НЕ ХВАТАТЕТ ПО ДВЕ
        [Test]
        public void M1_ExactlyOneNoTwo()
        {
            string result = Helper("5 6");
            Assert.AreEqual("1", result);
        }

        //ХВАТАЕТ ПО ДВЕ РЫБЫ РОВНО
        [Test]
        public void N1_ExactlyTwo()
        {
            string result = Helper("5 10");
            Assert.AreEqual("2", result);
        }

        //ВСЕМ ХВАТАТЕТ ПО ДВЕ РЫБЫ, НО НЕ ХВАТАЕТ ПО ТРИ
        [Test]
        public void O1_ExactlyTwoNoThree()
        {
            string result = Helper("5 12");
            Assert.AreEqual("2", result);
        }

        //ХВАТАЕТ ПО ТРИ РЫБЫ РОВНО
        [Test]
        public void P1_ExatlyThree()
        {
            string result = Helper("5 15");
            Assert.AreEqual("3", result);
        }

        //ВСЕМ ХВАТАЕТ ПО ТРИ РЫБЫ, НО НЕ ХВАТАЕТ ПО ЧЕТЫРЕ
        [Test]
        public void Q1_ExactlyThreeNoFour()
        {
            string result = Helper("5 16");
            Assert.AreEqual("3", result);
        }

        //МЕНЬШЕ 10^4 РЫБ, 100 РЫБАКОВ
        [Test]
        public void R1_LessFishMaxFishman()
        {
            string result = Helper("100 9999");
            Assert.AreEqual("99", result);
        }

        //10^4 РЫБ, МЕНЬШЕ 100 РЫБАКОВ
        [Test]
        public void S1_MaxFishLessFishman()
        {
            string result = Helper("99 10000");
            Assert.AreEqual("101", result);
        }

        //10^4 РЫБ, 100 РЫБАКОВ
        [Test]
        public void T1_MaxFishMaxFishman()
        {
            string result = Helper("100 10000");
            Assert.AreEqual("100", result);
        }

        //
        //ЗАДАНИЕ 4
        //

        //
        //HELP METHODS
        //

        private bool ValidateInputFromFile2(string filePath)
        {
            // Читаем все строки из файла
            var lines = File.ReadAllLines(filePath);

            // Проверяем, что файл содержит как минимум 3 строки
            if (lines.Length < 3) return false;

            // Проверяем первую строку на наличие двух натуральных чисел
            var firstLineParts = lines[0].Split(' ');
            if (firstLineParts.Length != 2) return false;

            // Проверяем, что оба элемента - натуральные числа
            if (!uint.TryParse(firstLineParts[0], out _) || !uint.TryParse(firstLineParts[1], out _)) return false;

            // Проверяем вторую строку на содержание только заглавных латинских букв и пробелов
            var petyaMessage = lines[1].Trim();
            if (string.IsNullOrEmpty(petyaMessage) || !petyaMessage.All(c => char.IsUpper(c) || char.IsWhiteSpace(c))) return false;

            // Проверяем третью строку на содержание только заглавных латинских букв и пробелов
            var newspaperText = lines[2].Trim();
            if (string.IsNullOrEmpty(newspaperText) || !newspaperText.All(c => char.IsUpper(c) || char.IsWhiteSpace(c))) return false;

            // Если все проверки пройдены, возвращаем true
            return true;
        }
        //
        private bool IsOutputFileValid2(string filePath)
        {
            // Читаем все строки из файла
            var lines = File.ReadAllLines(filePath);

            // Проверяем, что файл содержит ровно одну строку
            if (lines.Length != 1) return false;

            // Получаем единственную строку и убираем лишние пробелы
            var input = lines[0].Trim();

            // Проверяем, что строка пустая, либо равна "GOOD NOTE", либо содержит одно слово
            return string.IsNullOrEmpty(input) || input == "GOOD NOTE" || input.Split(' ').Length == 1;
        }
        public string Helper2(string inputValue)
        {
            // Создание временных файлов
            string inputFile = Path.GetTempFileName();
            string outputFile = Path.GetTempFileName();
            try
            {
                // Подготовка входных данных
                File.WriteAllText(inputFile, inputValue);
                // Запуск программы
                Program2.Main(new string[] { inputFile, outputFile });
                // Чтение результата
                return File.ReadAllText(outputFile).Trim();
            }
            finally
            {
                // Удаление временных файлов
                if (File.Exists(inputFile)) File.Delete(inputFile);
                if (File.Exists(outputFile)) File.Delete(outputFile);
            }
        }

        //ПРАВИЛЬНОЕ НАЗВАНИЕ NAMESPACE
        [Test]
        public void A2_Namespace()
        {
            string actualNamespace = typeof(Program2).Namespace;

            Assert.AreEqual(expectedNamespace2, actualNamespace);
        }

        //НАЛИЧИЕ ФАЙЛА С ВХОДНЫМИ ДАННЫМИ
        [Test]
        public void B2_InputFileExists()
        {
            Assert.IsTrue(File.Exists(inputPath2), $"Файл {inputPath2} не найден.");
        }

        //НАЛИЧИЕ ФАЙЛА ДЛЯ ВЫВОДА РЕЗУЛЬТАТА
        [Test]
        public void C2_OutputFileExists()
        {

            // Проверяем наличие файлов
            Assert.IsTrue(File.Exists(outputPath2), $"Файл {outputPath2} не найден.");
        }

        //КОРРЕКТНОСТЬ ВХОДНЫХ ДАННЫХ
        [Test]
        public void D2_InputFileDate()
        {
            Assert.IsTrue(ValidateInputFromFile2(inputPath2));
        }

        //В записке и в тексте по одному слову, ситуация хорошая

        [Test]
        public void F2_ПоОдномуСловуХорошо()
        {
            string result = Helper2("6 6\nПРИВЕТ\nПРИВЕТ");
            Assert.AreEqual("GOOD NOTE", result);
        }

        //В записке и в тексте по одному слову, ситуация плохая
        [Test]
        public void G2_ПоОдномуСловуПлохо()
        {
            string result = Helper2("6 6\nПРИВЕТ\nПЛОХОЙ");
            Assert.AreEqual("ПРИВЕТ", result);
        }

        //В записке одно слово, в тексте много, ситуация хорошая
        [Test]
        public void H2_ОдноМногоХорошо()
        {
            string result = Helper2("6 23\nПРИВЕТ\nПОКА ДЕЛА ПРИВЕТ ХОРОШО");
            Assert.AreEqual("GOOD NOTE", result);
        }

        //В записке одно слово, в тексте много, ситуация плохая
        [Test]
        public void I2_ОдноМногоПлохо()
        {
            string result = Helper2("6 16\nПРИВЕТ\nДЕЛА ПОКА ХОРОШО");
            Assert.AreEqual("ПРИВЕТ", result);
        }

        //В записке и в тексте много слов, «плохое» слово одно,оно отсутствует в тексте.
        [Test]
        public void J2_МногоСловОдноПлохое()
        {
            string result = Helper2("16 16\nПРИВЕТ ПОКА ДЕЛА\nПРИВЕТ ПОКА КЕДЫ");
            Assert.AreEqual("ДЕЛА", result);
        }

        //В записке и в тексте много слов, «плохое» слово одно,оно присутствует в тексте в недостаточном количестве
        [Test]
        public void K2_МногоСловОдноПлохоеНедостаточно()
        {
            string result = Helper2("21 21\nДЕЛА ДЕЛА КЕДЫ ПРИВЕТ\nПРИВЕТ КЕДЫ ДЕЛА ПОКА");
            Assert.AreEqual("ДЕЛА", result);
        }

        // 7-10 большими длинами текста и малой длиной записки.
        //7
        [Test]
        public void L2_БольшойТекстМаленькаяЗаписка_3_Хорошо()
        {
            string result = Helper2("9 138\nУЧАСТНИКИ\nВСЕ ПОСТОЯННЫЕ И НЕПОСТОЯННЫЕ УЧАСТНИКИ ДАННОГО ПРОЕКТА НЕОЖИДАННО ДЛЯ СЕБЯ ПОЛУЧИЛИ УДИВИТЕЛЬНУЮ И ДАЖЕ БЕСПРЕЦЕДЕНТНО РЕДКУЮ ВОЗМОЖНОСТЬ");
            Assert.AreEqual("GOOD NOTE", result);
        }

        //8
        [Test]
        public void M2_БольшойТекстМаленькаяЗаписка_4_Плохо()
        {
            string result = Helper2("3 138\nЕЖИ\nВСЕ ПОСТОЯННЫЕ И НЕПОСТОЯННЫЕ УЧАСТНИКИ ДАННОГО ПРОЕКТА НЕОЖИДАННО ДЛЯ СЕБЯ ПОЛУЧИЛИ УДИВИТЕЛЬНУЮ И ДАЖЕ БЕСПРЕЦЕДЕНТНО РЕДКУЮ ВОЗМОЖНОСТЬ");
            Assert.AreEqual("ЕЖИ", result);
        }

        //9
        [Test]
        public void N2_БольшойТекстМаленькаяЗаписка_5_ПлохоОдно()
        {
            string result = Helper2("18 138\nВСЕ ПОСТОЯННЫЕ УЧАСТНИКИ ЕЖИ\nВСЕ ПОСТОЯННЫЕ И НЕПОСТОЯННЫЕ УЧАСТНИКИ ДАННОГО ПРОЕКТА НЕОЖИДАННО ДЛЯ СЕБЯ ПОЛУЧИЛИ УДИВИТЕЛЬНУЮ И ДАЖЕ БЕСПРЕЦЕДЕНТНО РЕДКУЮ ВОЗМОЖНОСТЬ");
            Assert.AreEqual("ЕЖИ", result);
        }

        //10
        [Test]
        public void O2_БольшойТекстМаленькаяЗаписка_6_ПлохоНеХватает()
        {
            string result = Helper2("18 138\nВСЕ ПОСТОЯННЫЕ УЧАСТНИКИ ЕЖИ ВСЕ\nВСЕ ПОСТОЯННЫЕ И НЕПОСТОЯННЫЕ УЧАСТНИКИ ДАННОГО ПРОЕКТА НЕОЖИДАННО ДЛЯ СЕБЯ ПОЛУЧИЛИ УДИВИТЕЛЬНУЮ И ДАЖЕ БЕСПРЕЦЕДЕНТНО РЕДКУЮ ВОЗМОЖНОСТЬ");
            Assert.AreEqual("ВСЕ", result);
        }

        //11–14. Повторяют тесты 3–6, но большими длинами текста и записки.
        //11
        [Test]
        public void E2_БольшойТекстБольшаяЗаписка_3_Хорошо()
        {
            string result = Helper2("26 200\nПРИВЕТ МИР\nПРИВЕТ, КАК ДЕЛА? МИР СЕГОДНЯ ОЧЕНЬ ХОРОШИЙ, И Я СЧИТАЮ, ЧТО ЭТО ОТЛИЧНАЯ ДНЯ ДЛЯ НОВЫХ ВОЗМОЖНОСТЕЙ.");
            Assert.AreEqual("GOOD NOTE", result);
        }

        //12
        [Test]
        public void P2_БольшойТекстБольшаяЗаписка_4_Плохо()
        {
            string result = Helper2("11 101\nДОБРОЕ УТРО\nСЕГОДНЯ ТЕПЛО И СОЛНЦЕ СИЯЕТ, НО НИКТО НЕ ЗНАЕТ, ЧТО ЖДЁТ НАС ЗА УГЛОМ, ВЕДЬ НОВЫЕ ВЫЗОВЫ УЖЕ БЛИЗКИ.");
            Assert.AreEqual("ДОБРОЕ", result);
        }

        //13
        [Test]
        public void Q2_БольшойТекстБольшаяЗаписка_4_ПлохоОдно()
        {
            string result = Helper2("26 129\nПРИВЕТ МИР ДЕЛА КАК ХЭШТЕГ\nПРИВЕТ КАК ДЕЛА МИР СЕГОДНЯ ОЧЕНЬ ХОРОШИЙ, И Я СЧИТАЮ, ЧТО ЭТО ОТЛИЧНАЯ ДНЯ ДЛЯ НОВЫХ ВОЗМОЖНОСТЕЙ.");
            Assert.AreEqual("ХЭШТЕГ", result);
        }

        //14
        [Test]
        public void R2_БольшойТекстБольшаяЗаписка_4_ПлохоНеХватает()
        {
            string result = Helper2("26 129\nПРИВЕТ МИР ДЕЛА КАК ПРИВЕТ\nПРИВЕТ, КАК ДЕЛА МИР СЕГОДНЯ ОЧЕНЬ ХОРОШИЙ, И Я СЧИТАЮ, ЧТО ЭТО ОТЛИЧНАЯ ДНЯ ДЛЯ НОВЫХ ВОЗМОЖНОСТЕЙ.");
            Assert.AreEqual("ПРИВЕТ", result);
        }

        //15 - Максимальный тест, ситуация хорошая.
        [Test]
        public void S2_МаксимальныйТекстХорошо()
        {
            // Создание текста, содержащего слово из записки
            string note = "ПРИВЕТ";
            string longText = new string('A', 9992) + " " + note;

            string inputData = $"18 {longText.Length}\n{note}\n{longText}";
            string result = Helper2(inputData);
            Assert.AreEqual("GOOD NOTE", result);
        }

        //16 - Максимальный тест, ситуация плохая.
        [Test]
        public void T2_МаксимальныйТекстПлохо()
        {
            // Создание текста, содержащего слово из записки
            string note = "ПРИВЕТ";
            string longText = new string('A', 9992) + " ХОРОШО";

            string inputData = $"18 {longText.Length}\n{note}\n{longText}";
            string result = Helper2(inputData);
            Assert.AreEqual("ПРИВЕТ", result);
        }

        //
        // 6 ЗАДАНИЕ
        //

        //
        //HELP METHODS
        //

        private bool ValidateInputFromFile6(string filePath)
        {
            // Читаем все строки из файла
            var lines = File.ReadAllLines(filePath);

            if (lines.Length == 1) return false;

            var firstLineParts = lines[0].Split(' ');
            if (firstLineParts.Length != 2) return false;

            if (!uint.TryParse(firstLineParts[0], out uint n) || n % 2 == 0) return false;
            if (lines.Length < n + 1) return false;
            if (!uint.TryParse(firstLineParts[1], out uint c) || c == 0) return false;

            for (int i = 1; i <= n; i++)
            {
                if (i >= lines.Length) return false;
                if (!uint.TryParse(lines[i].Trim(), out uint p) || p == 0) return false; // Проверка на натуральное число
            }

            return true;
        }
        //
        private bool IsOutputFileValid6(string filePath)
        {

            // Читаем содержимое файла и убираем лишние пробелы
            var input = File.ReadAllText(filePath).Trim();

            if (string.IsNullOrEmpty(input)) return true;

            var parts = input.Split(' ');

            if (parts.Length != 1) return false;

            // Проверяем, что элемент - целое число
            return int.TryParse(parts[0], out _);
        }
        public string Helper6(string inputValue)
        {
            // Создание временных файлов
            string inputFile = Path.GetTempFileName();
            string outputFile = Path.GetTempFileName();
            try
            {
                // Подготовка входных данных
                File.WriteAllText(inputFile, inputValue);
                // Запуск программы
                Program6.Main(new string[] { inputFile, outputFile });
                // Чтение результата
                return File.ReadAllText(outputFile).Trim();
            }
            finally
            {
                // Удаление временных файлов
                if (File.Exists(inputFile)) File.Delete(inputFile);
                if (File.Exists(outputFile)) File.Delete(outputFile);
            }
        }

        //
        //
        //



        //ПРАВИЛЬНОЕ НАЗВАНИЕ NAMESPACE
        [Test]
        public void A6_Namespace()
        {
            string actualNamespace = typeof(Program6).Namespace;

            Assert.AreEqual(expectedNamespace6, actualNamespace);
        }

        //НАЛИЧИЕ ФАЙЛА С ВХОДНЫМИ ДАННЫМИ
        [Test]
        public void B6_InputFileExists()
        {
            Assert.IsTrue(File.Exists(inputPath6), $"Файл {inputPath6} не найден.");
        }

        //НАЛИЧИЕ ФАЙЛА ДЛЯ ВЫВОДА РЕЗУЛЬТАТА
        [Test]
        public void C6_OutputFileExists()
        {

            // Проверяем наличие файлов
            Assert.IsTrue(File.Exists(outputPath6), $"Файл {outputPath6} не найден.");
        }

        //КОРРЕКТНОСТЬ ВХОДНЫХ ДАННЫХ
        [Test]
        public void D6_InputFileDate()
        {
            Assert.IsTrue(ValidateInputFromFile6(inputPath6));
        }

        //5

        [Test]
        public void E6_OutputFileDate()
        {
            Assert.IsTrue(IsOutputFileValid6(outputPath6));
        }

        //6
        [Test]
        public void G6_()
        {
            string result = Helper6("1 100\n3");
            Assert.AreEqual("200", result);
        }

        //7
        [Test]
        public void H6_()
        {
            string result = Helper6("3 10\n7\n14\n5");
            Assert.AreEqual("150", result);
        }

        //8
        [Test]
        public void I6_()
        {
            string result = Helper6("5 15\n10\n10\n10\n10\n10");
            Assert.AreEqual("450", result);
        }

        //9
        [Test]
        public void J6_е()
        {
            string result = Helper6("1 0\n10");
            Assert.AreEqual("0", result);
        }

        //10
        [Test]
        public void K6_()
        {
            string result = Helper6("1 1\n1");
            Assert.AreEqual("1", result);
        }

        //11
        [Test]
        public void L6_()
        {
            string result = Helper6("1 10\n2");
            Assert.AreEqual("20", result);
        }

        //12
        [Test]
        public void M6_()
        {
            string result = Helper6("3 5\n1\n3\n5");
            Assert.AreEqual("30", result);
        }

        //13
        [Test]
        public void N6_()
        {
            string result = Helper6("1 1000000000\n1");
            Assert.AreEqual("1000000000", result);
        }

        //14
        [Test]
        public void O6_()
        {
            string result = Helper6("3 100\n1000000\n1000000\n1000000");
            Assert.AreEqual("150000300", result);
        }

        //15
        [Test]
        public void E6_()
        {
            string result = Helper6("11 50\n1\n1\n1\n1\n1\n1\n1\n1\n1\n1\n1");
            Assert.AreEqual("550", result);
        }

        //16
        [Test]
        public void P6_()
        {
            string result = Helper6("1 100\n10000000");
            Assert.AreEqual("500000100", result);
        }

        //17
        [Test]
        public void Q6_()
        {
            string result = Helper6("3 333333333\n1\n1\n1");
            Assert.AreEqual("999999999", result);
        }

        //18
        [Test]
        public void R6_()
        {
            string result = Helper6("1 1\n0");
            Assert.AreEqual("0", result);
        }

        //19
        [Test]
        public void S6_()
        {
            string result = Helper6("1 1\n1999999999");
            Assert.AreEqual("1000000000", result);
        }

        // 20
        [Test]
        public void T6_()
        {
            string result = Helper6("7 142857142\n1\n1\n1\n1\n1\n1\n1");
            Assert.AreEqual("999999994", result);
            //}

        }
    }
}