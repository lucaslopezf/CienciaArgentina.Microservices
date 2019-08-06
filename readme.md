# Tests

## Estructura de carpetas
Respeta la estructura del proyecto (Application - Common - Infrastructure - Worker).

## Unit testing
Para que sea más fácil y rápido encontrar un test usamos la estructura que proponen en https://haacked.com/archive/2012/01/02/structuring-unit-tests.aspx/, una clase que contenga clases con el nombre del método a testear. Cada clase tiene métodos que son pruebas de los diferentes casos que se le pueden aplicar y usan un nombre descriptivo con la estructura [Subject]_[Scenario]_[Result] (AddUser_EmptyUsername_ReturnsFalse).