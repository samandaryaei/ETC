namespace ETC.PoliceInquery.Shared
{
    public static class ApplicationVariables
    {
        public static Dictionary<string, string> PlateNumberLetterCode = new()
        {
            { "01","الف"},
            { "02","ب"},
            { "03","ت"},
            { "04","ج"},
            { "05","د"},
            { "06","س"},
            { "07","ص"},
            { "08","ط"},
            { "09","ع"},
            { "10","ق"},
            { "11","ل"},
            { "12","م"},
            { "13","ن"},
            { "14","و"},
            { "15","ه"},
            { "16","ی"},
            { "18","ک"},
            { "19","ژ"},
            { "20","ف"},
            { "21","پ"},
            { "23","ز"},
            { "90","ث"},
            { "91","ش"},
            { "95","D"},
            { "96","S"},
            { "99","گ"},
        };

        public static List<CarClassMapping> CarClassMappings = new()
        {
            new CarClassMapping("97","M","انواع عمرانی","عمرانی"),
            new CarClassMapping("98","N","انواع موتور سیکلت","موتور سیکلت"),
            new CarClassMapping("99","O","انواع کشاورزی","کشاورزی"),
            new CarClassMapping("96","R","دوچرخه","دوچرخه"),
            new CarClassMapping("95","S","انواع تراکتور","تراکتور"),
            new CarClassMapping("1","A","انواع سواری","سواری"),
            new CarClassMapping("1","AO","کارکرایه - کارکرایه روستایی","سواری"),
            new CarClassMapping("1","A4","ون","سواری"),
            new CarClassMapping("1","K","اتوکمپینگ","اتوکمپینگ"),
            new CarClassMapping("1","L","انواع آمبولانس","آمبولانس"),
            new CarClassMapping("2","J","انواع وانت","وانت"),
            new CarClassMapping("2","J0","انواع ویژه حمل و نقل روستایی","وانت"),
            new CarClassMapping("2","J1","انواع امداد و نجات","وانت"),
            new CarClassMapping("2","J2","انواع آتش نشانی","وانت"),
            new CarClassMapping("2","J3","مخصوص حمل سیلندرگاز","وانت"),
            new CarClassMapping("2","J3","تانکرحمل سوخت","وانت"),
            new CarClassMapping("3","H","انواع مینی بوس","مینی بوس"),
            new CarClassMapping("3","H1","انواع آمبولانس","مینی بوس"),
            new CarClassMapping("4","E","انواع کامیونت","کامیونت"),
            new CarClassMapping("4","E2","انواع آتش نشانی","کامیونت"),
            new CarClassMapping("4","E3","انواع حمل مواد سوختی","کامیونت"),
            new CarClassMapping("4","E4","انواع ون","کامیونت"),
            new CarClassMapping("5","D","انواع اتوبوس","اتوبوس"),
            new CarClassMapping("5","D1","انواع آمبولانس","اتوبوس"),
            new CarClassMapping("6","C","انواع کامیون","کامیون"),
            new CarClassMapping("6","C1","انواع امداد و نجات","کامیون"),
            new CarClassMapping("6","C2","انواع آتش نشانی","کامیون"),
            new CarClassMapping("6","C3","انواع مواد سوخت و شیمیایی","کامیون"),
            new CarClassMapping("6","P","انواع یدک کش","یدک کش"),
            new CarClassMapping("6","T","انواع جرثقیل","جرثقیل"),
            new CarClassMapping("10","F","انواع کامیون کشنده","کامیون کشنده"),
            new CarClassMapping("10","I","انواع تریلی","تریلی"),
            new CarClassMapping("10","I3","انواع مواد سوختی و شیمیایی","تریلی"),
            new CarClassMapping("10","Q","تانکر حمل گازمایع","تریلی کش تانکر"),
            new CarClassMapping("10","U","کشنده یدک","کامیون مسقف چادری"),
            new CarClassMapping("11","I3","تريلي کش تانکر حمل مواد سوختي","تریلی"),
            new CarClassMapping("12","G","انواع نيمه يدک کش ","نيمه يدک کش"),
            new CarClassMapping("12","G3","انواع مواد سوختي و شيميايي","نيمه يدک کش"),
            new CarClassMapping("13","A0","کرايه","سواری"),
            new CarClassMapping("13","A0","کرايه بين شهري","سواری"),
            new CarClassMapping("13","B","تاکسی","سواری"),
            new CarClassMapping("13","B","تاکسی","تاکسی"),
            new CarClassMapping("13","B","کار","تاکسی")
        };

        public static readonly byte[] _salt = new byte[32]; //TODO مقدار را باید از پلیس گرفت
    }
}
