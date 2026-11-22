using System;

// کلاس اصلی که شامل دو تابع تحلیل و تولید رمز عبور است
class PasswordTool
{
    // تابع اول: تحلیل قدرت رمز عبور کاربر
    public static void AnalyzePassword()
    {
        Console.WriteLine("\n==================================");
        Console.WriteLine("     Password Strength Analyzer   ");
        Console.WriteLine("==================================");

        // دریافت رمز عبور از کاربر
        Console.Write("Enter your password: ");
        string password = Console.ReadLine();

        // بررسی اینکه رمز خالی نباشد
        //null یعنی خالی بودن
        //lenght نشان دهنده تعداد کاراکتر های موجود در یک رشته یا آرایه
        if (password == null || password.Length == 0)
        {
            Console.WriteLine("[!] No password entered.");
            return;
        }

        // متغیرها برای بررسی نوع کاراکترها
        int score = 0;
        //امتیاز پسورد
        bool hasLower = false;
        //حروف کوچک
        bool hasUpper = false;
        //حروف بزرگ
        bool hasDigit = false;
        //اعداد
        bool hasSpecial = false;
        //کاراکترها

        // بررسی تک‌تک کاراکترها با حلقه و شرط
        for (int i = 0; i < password.Length; i++)
        {
            char c = password[i];

            if (c >= 'a' && c <= 'z') hasLower = true;
            else if (c >= 'A' && c <= 'Z') hasUpper = true;
            else if (c >= '0' && c <= '9') hasDigit = true;
            else hasSpecial = true;
        }

        // امتیازدهی بر اساس طول رمز (هر سطح یک امتیاز)
        if (password.Length >= 8) score++;
        if (password.Length >= 12) score++;
        if (password.Length >= 16) score++;

        // امتیازدهی بر اساس تنوع نوع کاراکترها
        // به ازای هر true یک واحد به score اضافه میشود
        if (hasLower) score++;
        if (hasUpper) score++;
        if (hasDigit) score++;
        if (hasSpecial) score++;

        // نمایش جزئیات بررسی
        Console.WriteLine("\n-- Check Details ------------------");
        //تعداد و طول رشته و بررسی خوب بودن و بد بودن بر اساس 8 کاراکتر
        Console.WriteLine("Length         : " + password.Length + " chars  " + (password.Length >= 8 ? "[OK]" : "[FAIL] (min 8)"));
        Console.WriteLine("Lowercase      : " + (hasLower ? "[OK] Found" : "[FAIL] Not found"));
        Console.WriteLine("Uppercase      : " + (hasUpper ? "[OK] Found" : "[FAIL] Not found"));
        Console.WriteLine("Digits         : " + (hasDigit ? "[OK] Found" : "[FAIL] Not found"));
        Console.WriteLine("Special chars  : " + (hasSpecial ? "[OK] Found" : "[FAIL] Not found"));

        // نمایش نتیجه نهایی بر اساس امتیاز کل (از ۷)
        Console.WriteLine("\n-- Result -------------------------");
        if (score <= 2)
            Console.WriteLine("[!!] Very Weak   (Score: " + score + "/7)");
        else if (score <= 4)
            Console.WriteLine("[!]  Weak        (Score: " + score + "/7)");
        else if (score == 5)
            Console.WriteLine("[~]  Medium      (Score: " + score + "/7)");
        else if (score == 6)
            Console.WriteLine("[+]  Strong      (Score: " + score + "/7)");
        else
            Console.WriteLine("[++] Very Strong (Score: " + score + "/7)");

        Console.WriteLine("-----------------------------------");
    }

    // تابع دوم: تولید رمز عبور تصادفی و قوی
    public static void GeneratePassword()
    {
        Console.WriteLine("\n==================================");
        Console.WriteLine("         Password Generator       ");
        Console.WriteLine("==================================");

        // دریافت طول مورد نظر از کاربر
        Console.Write("Enter a length (recommended: 16): ");
        string input = Console.ReadLine();
        int length;

        // اگر مقدار وارد‌شده معتبر نبود، طول پیش‌فرض 8 تنظیم می‌شه
        if (length < 8)
        {
            Console.WriteLine("[!] Invalid value. Length set to default: 8");
            length = 8 ;
        }

        // تعریف مجموعه کاراکترهای مجاز برای هر دسته
        string lower = "abcdefghijklmnopqrstuvwxyz";
        string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string digits = "0123456789";
        string special = "!@#$%^&*-_=+?";
        string allChars = lower + upper + digits + special;

        // ایجاد منبع تصادفی
        Random rnd = new Random();
        //تولید یک آرایه به طول length
        char[] password = new char[length];

        // تضمین وجود حداقل یک کاراکتر از هر دسته در رمز تولیدی
        password[0] = lower[rnd.Next(lower.Length)];
        password[1] = upper[rnd.Next(upper.Length)];
        password[2] = digits[rnd.Next(digits.Length)];
        password[3] = special[rnd.Next(special.Length)];

        // پر کردن مابقی موقعیت‌ها با کاراکتر تصادفی از کل مجموعه
        for (int i = 4; i < length; i++)
            password[i] = allChars[rnd.Next(allChars.Length)];

        // تبدیل آرایه کاراکتری به رشته و نمایش نتیجه
        string result = new string(password);

        Console.WriteLine("\n-- Generated Password -------------");
        Console.WriteLine("  " + result);
        Console.WriteLine("-----------------------------------");
    }
}
