# TestTaskSurvey
# Запуск
Клонировать репозиторий и в корневой папке запустить комманду ```docker-compose up```
Порт по которому можно обращаться к api : ```5000```
# SQL-snapshot 

-- Вставка данных в таблицу Surveys
INSERT INTO "Surveys" ("Id", "Title", "Description", "CreatedAt") 
VALUES 
('df658a66-9bd3-4f2a-a4bb-d2522fc18d8c', 'Опрос об удовлетворенности клиентов', 'Опрос направлен на сбор отзывов о качестве обслуживания', NOW()),
('f201b22e-ad17-4d0b-8a50-ca092fa617bb', 'Опрос об условиях труда', 'Исследование для оценки условий работы сотрудников', NOW()),
('ee9c4002-01ba-4ef9-860f-e21770a24a5e', 'Опрос о продуктах компании', 'Сбор мнений клиентов по поводу новых продуктов', NOW());

-- Вставка данных в таблицу Questions
INSERT INTO "Questions" ("Id", "SurveyId", "Text", "Order") 
VALUES 
('a1b2c3d4-5678-9abc-def0-123456789abc', 'df658a66-9bd3-4f2a-a4bb-d2522fc18d8c', 'Насколько вы довольны обслуживанием?', 1),
('b2c3d4e5-6789-abcd-ef01-23456789abcd', 'df658a66-9bd3-4f2a-a4bb-d2522fc18d8c', 'Какова вероятность, что вы порекомендуете нас другим?', 2),
('c3d4e5f6-789a-bcde-f012-3456789abcd1', 'f201b22e-ad17-4d0b-8a50-ca092fa617bb', 'Удовлетворены ли вы условиями работы?', 1);

-- Вставка данных в таблицу Answers
INSERT INTO "Answers" ("Id", "QuestionId", "Text")
VALUES 
('d4e5f6a7-89ab-cdef-0123-456789abcde1', 'a1b2c3d4-5678-9abc-def0-123456789abc', 'Полностью доволен'),
('e5f6a7f8-9abc-def0-1234-56789abcdef2', 'a1b2c3d4-5678-9abc-def0-123456789abc', 'Скорее доволен'),
('f6a7f8e9-abcd-ef01-2345-6789abcdef03', 'b2c3d4e5-6789-abcd-ef01-23456789abcd', 'Очень вероятно');


insert into "Interviews" ("Id", "SurveyId", "UserId", "StartedAt", "CompletedAt")
values ('fdcfaeef-3989-40f9-a0e3-02e46712de2f', 'df658a66-9bd3-4f2a-a4bb-d2522fc18d8c', null, NOW(), null);
