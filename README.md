## Задачи (deadline 27.03.2019, 24.00)
1. Реализовать алгоритм FindNthRoot, позволяющий вычислять корень **n**-ой степени ( n ∈ N ) из вещественного числа **а** методом Ньютона с заданной точностью.
    - Разработать модульные тесты. 
2. Реализовать метод **NextBiggerThan**, который принимает положительное целое число и возвращает ближайшее наибольшее целое, состоящее из цифр исходного числа, и null, если такого числа не существует. (**Padawans Task #6**)
   - Разработать модульные тесты для тестирования метода. 
3. Разработать класс, позволяющий выполнять вычисления НОД по алгоритму Евклида для двух, трех и т.д. целых чисел
(http://en.wikipedia.org/wiki/Euclidean_algorithm , https://habrahabr.ru/post/205106/, https://habrahabr.ru/post/205106/ ). 
Методы класса помимо вычисления НОД должны предоставлять дополнительную возможность определения значение времени, 
необходимое для выполнения расчета. Добавить к разработанному классу методы, реализующие алгоритм Стейна (бинарный алгоритм Евклида) 
для расчета НОД двух, трех и т.д. целых чисел (http://en.wikipedia.org/wiki/Binary_GCD_algorithm, https://habrahabr.ru/post/205106/ ),
а также методы,  предоставляющие дополнительную возможность определения значение времени, необходимое для выполнения расчета.
Рассмотреть различные возможности реализации методов, возвращающих время вычисления НОД. Разработать модульные тесты.

## Реализация (Done)
1. - [Решение](https://github.com/arinkarus/NET1.S.2019.Chemrukova.03/blob/master/MathematicalOperations/MathOperations.cs)
   - [Тесты](https://github.com/arinkarus/NET1.S.2019.Chemrukova.03/blob/master/MathematicalOperations.Test/MathOperationsTests.cs)
2. - [Решение](https://github.com/arinkarus/NET1.S.2019.Chemrukova.03/blob/master/MathematicalOperations/NumberFinder.cs)
   - [Тесты](https://github.com/arinkarus/NET1.S.2019.Chemrukova.03/blob/master/MathematicalOperations.Test/NumberFinderTests.cs)
3. - [GCDAlgorithm](https://github.com/arinkarus/NET1.S.2019.Chemrukova.03/blob/master/MathematicalOperations/GCDAlgorithm.cs)
   - [GCDAlgorithms](https://github.com/arinkarus/NET1.S.2019.Chemrukova.03/blob/master/MathematicalOperations/GCDAlgorithms.cs)
   - [Тесты](https://github.com/arinkarus/NET1.S.2019.Chemrukova.03/blob/master/MathematicalOperations.Test/MathOperationsTests.cs)
