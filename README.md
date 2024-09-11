# Informe de Estructura del Proyecto Gwent.Pro

## Descripción General
El proyecto Gwent.Pro es un juego de cartas inspirado en Gwent, donde los jugadores pueden crear y probar cartas personalizadas. El proyecto está escrito principalmente en C# y utiliza ShaderLab y HLSL para los efectos visuales. La estructura del proyecto está organizada de manera modular, con una clara separación entre la lógica del juego, el sistema de compilación de cartas, la interfaz gráfica, y el soporte backend.

## Estructura General del Proyecto

### 1. Carpetas Principales
El proyecto está dividido en varias carpetas clave:

- Assets: Contiene los recursos gráficos y de interfaz, como imágenes, sprites, y otros elementos visuales que se muestran en el juego.
- Scripts: Aquí se encuentran los scripts que implementan la lógica del juego, la compilación de cartas y las interacciones entre los jugadores y las cartas. Es el corazón del sistema de juego.
- Shaders: Esta carpeta contiene los shaders utilizados para los efectos visuales y gráficos del juego, implementados en ShaderLab y HLSL.

### 2. Sistema de Compilación de Cartas
El sistema de compilación de cartas permite a los jugadores cargar un archivo de texto con definiciones de cartas. Este archivo incluye información sobre el nombre de la carta, su fuerza, habilidades especiales, y otros atributos. El script encargado de la compilación realiza las siguientes tareas:
- Lexer: Divide el texto en tokens o secuencias de texto lógicas, compatibles con el DSL para facilitar su posterior procedamiento, también elimina caracteres no necesarios como espacio y cambio de línea.
- Parser- Se encarga de construir un Árbol de Sintaxis Abstracta (AST) a partir de los tokens recibidos del Lexer, asignando así los argumentos en funciones, verificando que se cumple la sintaxis establecida en el DSL y estableciendo el orden de prioridad en expresiones aritmméticas entre otras funciones.
- Semantic- Chequea que el código generado tenga sentido desde el punto de vista semántico. Donde ya se manejan errores de tipado y otros.
- Evaluate- Recibe el AST chequeado semánticamente, y devuelve objetos listos para interactuar con el juego, en caso de una compilación exitosa.
- Manejo de Errores: Si se detecta un error en la definición de la carta, este se muestra en la consola del juego, especificando el problema para que el jugador lo corrija.

#### Ejemplo de Funciones Clave:
- Tokenize(): Encargada de la tokenización de texto.
- ParseExpression() y ParsePrimaryExpression(): Trabajan de la mano y son la base de la construcción del AST.
- Semantic(): Se encuentra en cada Expression, y es el encargado de chequear semánticamente.
- Evaluate(): También presente en todas las Expression, con el objetivo de crear, mediante recursividad y el uso de estructuras de datos, las cartas que serán jugadas.
- Execute(): Ya dentro del juego, su función es dar vida a los efectos de las cartas ejecutando el bloque Action de cada efecto asignado.
- SendPrincipal(): Muestra los errores encontrados durante la compilación en la pantalla.

### 3. Lógica de Juego
La lógica del juego se basa en una serie de scripts que controlan la interacción entre las cartas, el estado de los jugadores, y las fases de juego (turnos, rondas, etc.). Estos scripts se encargan de:
- Manejo de Turnos y Rondas: Controlan el flujo del juego, determinando cuándo es el turno de cada jugador y cuándo una ronda termina.
- Interacción de Cartas: Gestionan los efectos de las cartas cuando se juegan, como aplicar daño, curar unidades o activar habilidades especiales.
- Manejo del Estado de los Jugadores: Controla la mano, el mazo, el cementerio y los puntos de vida de cada jugador.

### 4. Interfaz de Usuario (UI)
La interfaz de usuario permite a los jugadores interactuar con el sistema de compilación y visualizar el estado del juego. Los scripts de la UI gestionan:
- Carga de Cartas: Una interfaz donde el jugador puede seleccionar archivos de cartas y ver los resultados de la compilación.
- Visualización del Tablero: La disposición gráfica del tablero donde las cartas son jugadas.
- Notificaciones: Mensajes que indican el estado del juego, como errores en la compilación o el fin de una ronda.

### 5. Gráficos y Efectos Visuales
Los efectos visuales del juego están implementados utilizando ShaderLab y HLSL, que se encuentran en la carpeta de Shaders. Estos shaders controlan cómo se muestran las cartas y sus efectos visuales en el tablero, añadiendo dinamismo y atractivo visual al juego.

## Flujo General del Juego
El flujo del juego está dividido en varias etapas:
1. Carga de Cartas: Los jugadores cargan cartas personalizadas mediante archivos de texto.
2. Compilación: Las cartas se validan y, si no hay errores, se incluyen en el mazo del jugador.
3. Inicio de la Partida: Comienza la partida y los jugadores toman turnos para jugar sus cartas.
4. Interacción de Cartas: Durante los turnos, las cartas juegan sus efectos y se enfrentan entre ellas.
5. Fin de la Ronda: Una vez terminada la ronda, se ajustan los puntajes y se determina el ganador.
6. Fin de Partida: Cuando se juegan todas las rondas, el sistema declara al ganador final.

## Conclusión
El proyecto Gwent.Pro está estructurado de manera modular, lo que facilita su mantenimiento y expansión. Cada componente clave —como la compilación de cartas, la lógica del juego, la interfaz de usuario y los gráficos— está bien separado en carpetas y scripts específicos, lo que permite un flujo de trabajo organizado y eficiente. Los jugadores tienen la capacidad de personalizar y probar nuevas cartas, lo que añade una capa de dinamismo al juego.

### Repositorio del Proyecto:
Gwent.Pro en GitHub
