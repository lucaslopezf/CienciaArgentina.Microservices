# Tests

## Estructura de carpetas
Respeta la estructura del proyecto (Application - Common - Infrastructure - Worker).

## Unit testing
Para que sea m�s f�cil y r�pido encontrar un test usamos la estructura que proponen en https://haacked.com/archive/2012/01/02/structuring-unit-tests.aspx/, una clase que contenga clases con el nombre del m�todo a testear. Cada clase tiene m�todos que son pruebas de los diferentes casos que se le pueden aplicar y usan un nombre descriptivo con la estructura [Subject]_[Scenario]_[Result] (AddUser_EmptyUsername_ReturnsFalse).