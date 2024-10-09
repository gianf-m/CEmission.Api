# CO2.Api
Aplicación de prueba.


Configuración de la aplicación:

Al descargar el codigo fuente de la aplicación se requiere configurar lo siguiente.

En el proyecto CEmissions.Api se debe abrir el Appsetings y configurar los parametros.

Sección: "ConnectionStrings:Default", debe tener una cadena de conexión validado (Ej: "Default": "server=localhost;database=CO2Db;user=root;password=123456789.")

Sección: "App:EnableCors", esta configuración es para habilitar o deshabilitar la configuración de los CORS. Por defecto esta en Verdadero. En caso de utilizar otro proyecto para validar el funcionamiento, se debe configurar la URL para que la API la acepte en la sección: "App:CorsOrigins", en caso de ser varias URL, se deben separar por "," sin espacios (EJ: "CorsOrigins": "https://localhost:44314,https://localhost:44313,https://localhost:44312")

Sección: "App:ExecuteMigrations", esta configuración le indica al proyecto si se desea ejecutar las migraciones que esten pendientes o en su defecto, crear la db y ejecutar las mismas. Por defecto esta en verdadero para facilitar la prueba de la API.

Al tener esto configurado, se debe tener como proyecto de inicio la API (Proyecto nombre CEmission.API) y ejecutar la misma.

Modelos:

    Login: 
        :Username string - Required
        :Password string - de 8 a 15 caracteres, mayusculas, minusculas, numeros y un caracter especial.

    IdentityUser:
        Create:
            :Username string - Required
            :Password string - de 8 a 15 caracteres, mayusculas, minusculas, numeros y un caracter especial.
            :Email string - Required
            :PhoneNumber string - Required
    
    Para el caso de los endpoints solicitados, se modifico el listar para agregar un filtrado opcional en base a alguno de los parametros de la entidad.

Existen 3 controladores protegidos por Autorización
    CompanyController,
    EmissionController,
    IdentityUserController

El endpoint libre es el LoginController para poder generar el token JWT y acceder a los demás endpoints:
    Por migración se hace seeding de un usuario master
        Username: Master,
        Password: GenericPw1.

Una vez generado el token, copiarlo en la sección de Authorize de swagger con la palabra Bearer + Token y se accede a los demas endpoints.

Para realizar las pruebas unitarias, solo se debe ejecutar la acción de "run test" en el menu de pruebas.
Los unit test tienen el header JWT del usuario master creado por defecto.




