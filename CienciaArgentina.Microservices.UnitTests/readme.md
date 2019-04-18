# Tests

La estructura de los test podría sería: 
- Projecto
	- Tipo de test
		- Carpeta que agrupe test / Test

## Diferencias entre tipos de test

### Unit tests:
Son test chicos sobre métodos específicos. Se busca que se trabaje sobre una sola función y una sola responsabilidad. Todo lo que hace debería ser sobre memoria y no debería:
 - Acceder a la network
 - Acceder a una base de datos
 - Usar el filesystem
 - De ser posible no debería llamar a otros métodos ni ser el resultado de un llamado
 - No usar threads
 - No usar system properties

Estos tests tienen que ser independientes del entorno.
Intentar limitar el tiempo de cada unit test a un máximo de 60 segundos.

### Component tests:
Se utiliza para testear un módulo en particular, como por ejemplo los métodos que conecten con la base de datos durante la creación de una cuenta.

### Integration tests:
Es el resultado de la combinatoria de units tests, de la combinación de los módulos testeados en component test y la verificación de que el resultado obtenido es el esperado; se busca testear la integración entre varias capas
Estos test pueden y deben usar threads, acceder a la base de datos y hacer lo necesario para que el funcionamiento sea el correcto sin depender del entorno. **Se tiene que usar el entorno próximo más parecido a producción**. No se recomienda el acceso a la network. También pueden incluir otros microservicios.
Limitar el máximo de tiempo de cada test de integración a un máximo de 300 segundos.

### Functional tests:
Son los tests que chequean que tan correcta es una funcionalidad comparando los resultados para cierto input. En estos test no importa lo que pase en el medio, sólo importa e lresultado. Deberían ser pensados de manera que "si tengo un método que se llama RaízCuadrada(x), con un argumento de 4 el resultado sea 2".

### End-to-end tests:
Mezcla los test en los cuales se buscan resultados de punta a punta en el sistema. En estas etapas es viable usar Selenium para pruebas con UI. 
Para las aplicaciones sin UI se prueba directamente las APIs mediante el uso de un cliente HTTP.
Tienen que ser lo más independiente posibles de la data.

##### Pirámide jerárquica de tests:
Según Martin Fowler la base de los tests son los unit tests, integration, component y end-to-end.

***

### Bibliografía utilizada:
- Martin Fowler - *Testing Strategies in a Microservice Architecture* (https://martinfowler.com/articles/microservice-testing/)
- Stack Overflow (https://stackoverflow.com/questions/4904096/whats-the-difference-between-unit-functional-acceptance-and-integration-test)
- Google - *Test Sizes* (https://testing.googleblog.com/2010/12/test-sizes.html)
- TryQA - *What are software testing levels?* (http://tryqa.com/what-are-software-testing-levels/)

