# Singularis_Test_Task
Singularis_Test_Task
 Тестовое задание в компанию Singularis Lab.
 Была создана база данных PostgreSQL. Файл експорта находится в корне проекта. Название: singularisBD.sql.
 
 
 
Напишите ASP.NET Web API, который будет предоставлять CRUD-операции для управления базой данных клиентов (имя, фамилия, дата рождения, email, телефон и адрес). 
Каждое поле представлено в виде строки. Клиенты должны храниться в памяти.
API должна содержать функции импорта/экспорта хранящихся клиентов из/в файл формата json. Файл должен содержать все данные о хранящихся клиентах. 
Добавьте логирование в ваше приложение. Логи должны содержать информацию о запросах, ошибках и другую информацию, которая поможет отслеживать работу приложения. 
 
Требования: 
•	ASP.NET Core 7 
•	Логгирование должно осуществляться с помощью встроенных средств
•	Должны быть реализованы CRUD-операции над пользователями: 
•	Получение списка пользователей с краткой информацией 
•	Получение пользователя по ID 
•	Редактирование пользователя 
•	Удаление пользователя 
•	Создание пользователя 
•	В зависимости от корректности и типа запроса, должен возвращаться соответствующий код ответа: 200, 400 и т.д. 
•	Должна быть функция экспорта пользователей в файл формата json (Сначала сериализовать все в json, потом добавить json в файл после данный файл вернуть на api)
•	Должна быть функция импорта пользователей из файла формата json 
 
Дополнительно: 
•	Использовать реальную базу данных и завернуть ее вместе с приложением в docker-compose  
•	Убрать возможность редактирования имени и даты рождения. 
•	Добавить возможность экспорта пользователей в файл формата Excel 
•	Добавить возможность импорта пользователей из файла формата Excel 
 
Пример запросов: 
•	Запрос: GET /users 
Ответ: Краткая информация о всех пользователях, содержащих id, имя и фамилию пользователя 
•	Запрос: GET /users/{id} 
Ответ: Информация о пользователе  
•	Запрос: POST /users 
Ответ: id созданного пользователя 
•	Запрос: DELETE /users/{id} 
Ответ: - 
•	Запрос: PUT /users/{id} 
Ответ: - 
•	Запрос: GET /users/export 
Ответ: файл со всеми пользователями 
•	Запрос: POST /users/import 
Ответ: - 

