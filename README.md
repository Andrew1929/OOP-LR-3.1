Завдання 1. Реалізуйте програму, яка читає файл CSV, що містить перелік транзакцій, і обчислює загальну суму грошей, витрачену за кожен день. Використовуйте делегати типу Func<string, DateTime> і Func<string, double>, щоб отримати дату та суму кожної транзакції з файлу CSV, і делегат типу Action<DateTime, double>, щоб відобразити загальну суму, витрачену на кожну з них. день. Перезапишіть данні в CSV файли по 10 записів у файлі. Використовуйте замикання для збереження поточних параметрів для шляху до файлу CSV і формату дати.
