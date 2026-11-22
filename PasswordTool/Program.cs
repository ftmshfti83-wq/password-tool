using System;

// فایل اصلی برنامه - فقط مسئول نمایش منو و هدایت کاربر است
class Program
{
    static void Main()
    {

        bool running = true;

        // حلقه اصلی برنامه که تا زمان انتخاب خروج ادامه می‌ده
        while (running)
        {
            // نمایش منوی اصلی
            Console.WriteLine("\n|       Password Manager Tool      |");
            Console.WriteLine("|                                  |");
            Console.WriteLine("|  [1]  Analyze Password Strength  |");
            Console.WriteLine("|  [2]  Generate Strong Password   |");
            Console.WriteLine("|  [0]  Exit                       |");
            Console.Write("\nEnter your choice: ");

            string choice = Console.ReadLine();

            // مسیریابی به تابع مربوطه بر اساس انتخاب کاربر
            switch (choice)
            {
                case "1":
                    // فراخوانی تابع تحلیل رمز از کلاس PasswordTool
                    PasswordTool.AnalyzePassword();
                    break;

                case "2":
                    // فراخوانی تابع تولید رمز از کلاس PasswordTool
                    PasswordTool.GeneratePassword();
                    break;

                case "0":
                    // خروج از حلقه و پایان برنامه
                    Console.WriteLine("\n|   Thanks for using our tool!     |");
                    Console.WriteLine("|           Goodbye!               |");
                    running = false;
                    break;

                default:
                    // مدیریت ورودی نامعتبر
                    Console.WriteLine("\n[!] Invalid choice. Please enter 0, 1 or 2.");
                    break;
            }
        }
    }
}
