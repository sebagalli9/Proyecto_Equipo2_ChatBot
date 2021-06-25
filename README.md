# Proyecto Equipo2 GiftBot
## PII UCU - Proyecto Final de Curso - Equipo 2 - Gift ChatBot

![Banner](./Assets/gift.png)

Llega el día del cumpleaños de la persona más importante para tí y suele pasar que no sabemos qué regalar. ¡No te preocupes! GiftBot es tu mejor asistente. Él te ayudará a construir un perfil basado en determinadas preguntas y te hará fantásticas sugerencias para tu próximo regalo.

## Resumen del funcionamiento del programa
Desde un conjunto de archivos externos se extrae la información necesaria para crear bancos que almacenan distintas clases de categorías de preguntas, las cuales se clasifican como: Initial, Main, Mixed y Specific. 

Las preguntas clasificadas como Initial están orientadas a recolectar información básica y general sobre la persona a quien se quiere regalar (tales como género y rango de edad) y sobre preferencias generales del usuario (tales como lugar de compra y presupuesto disponible). Las preguntas clasificadas como Initial estan ideadas exclusivamente para guardar información que no está directamente relacionada con el producto final, pero aún así es información que enriquece los criterios de búsqueda del regalo acorde a las preferencias del usuario y las características generales de la persona a quien se quiere regalar.

Las preguntas clasificadas como Initial son las primeras en interactuar con el usuario una vez que se inicia el procedimiento para la recomendación de regalos. Cada una de estas preguntas cuenta con respuestas preestablecidas entre las cuales el usuario debe elegir. La opción de respuesta a cada pregunta seleccionada por el usuario se almacena en lo que llamamos un Perfil de Persona. 

```
Ejemplo de formato de archivo de preguntas clasificadas como Initial:
¿Cual es género de la persona a la que le quieres regalar?;1-mujer,2-hombre
```

Las categorías clasificadas como Main almacenan una afirmación identificadora que representa una categoría general de productos. Una categoría Main es el nivel más amplio o genérico en el que se puede clasificar una categoría (Ejemplos: Home, Sport, Technology).

Las categorías clasificadas como Main son las segundas en interactuar con el usuario. Entre una lista de afirmaciones, el usuario debe elegir aquellas dos afirmaciones que sean más acorde a la persona a quien quiere regalarle. Las dos categorías Main seleccionadas por el usuario a partir de las afirmaciones se almacenan en el antes mencionado Perfil de la Persona.

```
Ejemplo de formato de archivo de preguntas clasificadas como Main:
Le gusta quedarse en casa;1-home
Es habil para el bricolage;2-tool
Le gusta la tecnología;3-technology
``` 
Las categorías clasificadas como Mixed almacenan preguntas asociadas a la combinación de dos categorías Main, donde además cada pregunta representa una categoría más específica dentro de dicha combinación de dos categorías Main.

Las categorías clasificadas como Mixed son las terceras en interactuar con el usuario. A partir de las dos categorías Main seleccionadas por el usuario, se realiza una búsqueda de las categorías Mixed que están asociadas a la combinación de dichas categorías Main. A partir de ello, se muestra un conjunto de preguntas nuevas que el usuario debe responder ingresando  "si" o un "no".

```
Ejemplo de formato de archivo de preguntas clasificadas como Mixed:
home;technology;¿Le gusta usar redes sociales?;cellphone
```

Las categorías clasificadas como Specific almacenan preguntas asociadas a un producto puntual (o una gama de productos).

Las categorías clasificadas como Specific son las últimas en interactuar con el usuario. A partir de aquellas preguntas Mixed a las que el usuario haya respondido "si", se muestra un nuevo conjunto de preguntas a las cuales el usuario debe responder ingresando "si" o un "no". 

```
Ejemplo de formato de archivo de preguntas clasificadas como Specific:
cellphone;¿Le gusta sacar fotos?;Iphone
```
Finalmente, aquella o aquellas preguntas clasificadas como Specific que hayan obtenido como respuesta un "si", devolverán un producto que posteriormente va a ser ingresado a una búsqueda en Mercado Libre.

![WHLogo](./Assets/logowhitehats.png)


