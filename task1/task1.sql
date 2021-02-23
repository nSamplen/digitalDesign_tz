
-- 1.       Сотрудник с максимальной заработной платой

select name
from EMPLOYEE
where salary = (select max(salary) from Employee);
go

-- 2.      Отдел, в котором работает сотрудник с самой высокой зарплатой.
select Department.name
from EMPLOYEE join DEPARTMENT on EMPLOYEE.department_id = DEPARTMENT.id
where EMPLOYEE.salary = (select max(EMPLOYEE.salary) from Employee);
go

-- 3.       Отдел с максимальной суммарной зарплатой сотрудников
select top (1) A.name
from 
    (select Department.id, Department.name, sum(EMPLOYEE.salary) as sum_salary
     from DEPARTMENT join EMPLOYEE on EMPLOYEE.department_id = DEPARTMENT.id
     group by Department.id, Department.name) as A
order by sum_salary desc;
go

-- 4.       Сотрудника, чье имя начинается на «Р» и заканчивается на «н».
select name
from EMPLOYEE
where name like 'Р%н';
go
