En nuestra empresa hemos guardado y recuperado las bitácoras de nuestros sistemas en bases de datos relacionales y de archivos durante años. Para ello un diseñador de antaño ha creado una interfaz llamada ILogger en la cual se han definidos los siguientes métodos: Store(Log) y GetAll() : List<Log>. Tenemos algunas clases concretas como SqlLogger y FileLogger que implementan dicha interfaz. (La clase Log tiene dos atributos: string message y enum Severity)
Un nuevo cliente nos ha pedido que es sus desarrollos utilicemos una clase que ya posee para estos fines llamada Logger (Recibe en el constructor un parámetro de tipo enum: File o SQL y otro parámetro de tipo string con el path/connString), la misma posee los métodos Write (string) y ReadAll(): string[] (El parámetro string sería el equivalente a nuestro string message de la clase Log y el cliente no desea determinar severidades para sus bitácoras, ya que toda la gestión es manejada con cadenas formateadas para tal fin).
A pesar de que utilizaremos su clase para guardar las bitácoras, queremos seguir utilizando la interfaz ILogger
para no apartarnos de nuestro estándar.
1) ¿Qué diseño le propondríamos a nuestro cliente para satisfacer el requerimiento? Desarrolle el nuevo modelo UML. Implemente la solución como una capa de servicios transversal. Haga sus pruebas con un proyecto de consola como cliente. (30)
2) Implemente en código C# la solución propuesta generando el modelo de base de datos (SQL) y formato de archivo que usted crea conveniente para realizar las bitácoras. (10)
3) Toda la información de rutas y cadenas de conexión deben ser parametrizados desde el archivo app.config y cargados al iniciar la aplicación en una clase llamada ApplicationSettings. (20)
4) ¿Cómo podríamos evitar que los clientes instancien las clases concretas SqlLogger y FileLogger? Implemente. (20)
5) En una nueva reunión el cliente nos comenta que desea agregar la funcionalidad de que al detectar en un mensaje la palabra “CriticalError”, se envíe un email a la casilla soporteNivel1@email.com. y si se detecta la palabra “FatalError” se envíe una copia a soporteNivel2@email.com ¿Cuál sería la mejor manera de plantear esa mejora tratando de modificar lo mínimo posible la clase Logger de nuestro cliente? Implemente su solución (No hace falta implementar el envío de emails). (20)
