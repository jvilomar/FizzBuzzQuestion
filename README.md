Jose Manuel Vilomar - Will DomTech Demo
=========================================================================================================

Fizz Buzz Demo App.

Introducción
------------

Este aplicativo consta de dos aplicaciones: Un back end que es nuestro web api,
y el front end que servirá como nuestro cliente.-

BackEnd
-------

El backend es una aplicación web api, desarrollada utilizando .Net Framework Core 5.0,
con C# como lenguaje de programación y SQL Lite como base de datos.

Para realizar la instalación, luego de clonar el repositorio, se necesita restaurar las
dependencias o paquetes de NuGet:

    1. En VisualStudio, Abrir la Solución.
    2. En Solution Explorer Hacer click derecho sobre la solución.
    3. Seleccionar Restore NuGet Packages

Para configurar la base de datos:

    1. Al ejecutar la aplicación por primera vez esta se encarga de crear la base de datos 
       sqlite y la tabla para registrar los request.


FrontEnd
------------

El front end es nuestra aplicación cliente y esta desarrollada utilizando Vuejs como framework JavaScript y BootstrapVue como framework CSS y es una aplicación basada en NodeJS.

> VueJS v2.6.11

> VuetifyJS v2.4

> La version de Nodejs es la 16.8.0.

Al igual que el Back - End, se necesita instalar las dependencias necesarias, por lo que debe verificar que tiene instalado NodeJS.  La version utilizada en este caso es la 16.8.0.

para verificar la version instalada ejecute el siguiente comando :

    node --version

Para instalar las dependencias, debe realizar los siguientes pasos:

    1. Acceder a la siguiente ruta:

      \Front\fizz-buzz

    2. Ejecutar el siguiente comando:

      yarn install

    3. Luego que se instalen  las dependencias, ejecutar el siguiente comando:

      yarn serve

Es necesario que el web api este ejecutandose para que el cliente pueda acceder al endpoint.
