# Proyecto_Equipo2_GiftBot
## PII UCU - Proyecto Final de Curso - Equipo 2 - Gift ChatBot

<p align="center">![Banner](./Assets/gift.png)</p>

Llega el día del cumpleaños de la persona más importante para tí y suele pasar que no sabemos qué regalar. ¡No te preocupes! FigtBot es tu mejor asistente. Él te ayudará a construir un perfil basado en determinadas preguntas y te hará fantásticas sugerencias para tu próximo regalo.

## Resumen de Experiencia de Usuario
1. “¿La persona a la que le quieres regalar es: hombre, mujer u otro?”
2. “¿La persona a la que le quieres regalar es: niño, adulto joven o adulto?”
3. “¿En qué departamento quieres hacer la compra?“
4. “¿Cuánto es lo máximo que quieres gastar?”
5. Aparece primera ronda de categorías 

Ejemplo: 
*Elije lo que creas que es más acorde a la persona a la que quieres regalarle:*
*1- Le gusta quedarse en casa 2- Es hábil para lo manual 3- Le gusta la tecnología*

6. Botones: *Buscar mi regalo* o *Siguiente pregunta*

(Buscar mi regalo)Se muestran productos acordes a la informacion que se dio hasta ahora (edad, sexo,etc, selectedCategory).
(Siguiente pregunta)Si quiere seguir buscando, se muestran las categorías cuya categoría padre sea la selectedCategory

7. Se repite procedimiento a partir de paso 5
8. Boton: Ya encontré mi regalo

## Resumen del flujo básico del programa
El programa lee un archivo txt donde de cada línea se extrae: el nombre de una categoría, el nombre de su categoría padre y un texto correspondiente a una opción que representa esa categoría. (Ejemplo: “Le gusta estar al aire libre” podría ser la opción que representa la categoría Garden).

```
Ejemplo de formato de archivo txt:
categoria: A, categoriaPadre: nombre, opción: opción
categoria: B, categoriaPadre: A, opción: opción
categoria: C, categoriaPadre: nombre, opción: opción
```

*(Nota: Todavía no está desarrollado cómo se va a identificar la categoría padre de las categorías que correspondan a la primer ronda)*

La información extraída sobre cada una de las categorías se usa para construir instancias de objetos categoría y dichos objetos se almacenan en una única lista (un banco de categorías).
A partir de esa lista de Categorías es de donde se extraen las categorías que aparecerán en cada ronda. En cada ronda, se va a presentar al usuario un número determinado de opciones entre las cuales va a tener que elegir una según la preferencia que tenga. Cada una de estas opciones representa su propia categoría (pues la opción es un atributo de la categoría) por lo que cuando el usuario haga la elección, estará eligiendo implícitamente una categoría.

La categoría elegida por el usuario se almacena en un atributo de la clase que representa el “Perfil de la Persona”. El valor de ese atributo se va a ir sobreescribiendo a medida que el usuario siga haciendo elecciones y siempre almacenará el valor de la última elección que haya hecho. Con esto, la clase responsable de generar las nuevas rondas va a tomar el valor de la última categoría elegida para poder buscar todas las categorías (en el banco de categorías) cuya categoría padre sea la última categoría elegida por la persona.

Cuando el usuario haga una elección por última vez (es decir, cuando la última categoría elegida ya no tenga categorías hijas), se va a utilizar ese último valor almacenado para realizar la búsqueda en Mercado Libre o Amazon.
La búsqueda que se va a realizar en la plataforma de venta de productos va a estar además sujeta a las preferencias en cuanto a precio,  lugar (ciudad o país) y estado del producto (nuevo o usado) que el usuario ingresa antes de que comiencen las rondas de opciones. Estas preferencias en particular corresponden a atributos del “Perfil de la Persona”, por lo que este perfil se va ir construyendo a medida que el usuario ingresa los datos correspondientes.



