  
/*1.  Сотрудник с максимальной заработной платой.*/
SELECT * FROM employee
WHERE salary = (SELECT MAX(salary) FROM employee);

/*2. Отдел, в котором работает сотрудник с самой высокой зарплатой.*/
SELECT departament.Name FROM departament, employee
WHERE employee.salary = (SELECT MAX(salary) FROM employee) AND employee.departament_Id = departament.Id;

/*3. Отдел с максимальной суммарной зарплатой сотрудников.*/
WITH SumOtd AS (
    SELECT d.Name, SUM(e.salary) AS dept_total
    FROM employee e JOIN departament d
    ON e.departament_Id = d.Id
    GROUP BY d.Name),
avg_cost AS (
    SELECT SUM(dept_total)/COUNT(*) AS dept_avg
    FROM SumOtd)
SELECT *
FROM SumOtd
WHERE dept_total >
        (SELECT dept_avg
        FROM avg_cost)
ORDER BY Name;

/*4  Сотрудник, чье имя начинается на «Р» и заканчивается на «н».*/
SELECT * FROM employee
WHERE name LIKE 'Р%н';
