### StatisticsUniqWordsHttp
Приложение, позволяющее скачивать произвольную HTML-страницу посредством HTTP-запроса на жесткий диск компьютера и выдавать статистику по количеству уникальных слов в консоль.

Консольное приложение Console App (.NET 5) разработано на языке C#.
Выполнение приложения осуществляется путем компиляции и запуска проекта StatisticsUniqWordsHttp, решение(Solution) StatisticsUniqWordsHttp.sln.

### Описание работы приложения
 - Выполняет запрос Web-страницы и сохраняет полученную страницу как файл на локальном диске в каталог иполняемого файла
 - Подсчитывает вхождения заданных уникальных слов из сохраненного файла
 - Выводит статистику в консоль 

### Сохранение статистики в базу данных
При выполнении подсчета статистики данные сохраняются в БД
- StatDb (master) - таблица запроса Web-страницы
- StatDetailDb (detail) - таблица статистики  

### Логирование ошибок в файл
Выполняет логирование ошибок и трассировку выполнения приложения в файл в каталог /logs

### Содержит юнит-тест метода подсчета статистики
Тест проверяет корректность работы метода CountWordsSearch - подсчет кол-ва слов в строке

### Test Fork
