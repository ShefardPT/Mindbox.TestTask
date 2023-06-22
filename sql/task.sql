-- Задание: В базе данных MS SQL Server есть продукты и категории. Одному продукту может соответствовать много категорий, в одной категории может быть много продуктов. Напишите SQL запрос для выбора всех пар «Имя продукта – Имя категории». 
-- Если у продукта нет категорий, то его имя все равно должно выводиться.

-- Пусть продуктам соотвествует таблица products, а категориям - categories
-- согласно постановке задачи между ними связи "many-to-many"
-- следовательно для реализации этой связи введем таблицу products_categories

-- тогда решение выглядит как 
select *
from products_categories as pc
right join products p on pc.product_id = p.id
left join categories c on pc.category_id = c.id;