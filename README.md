"# agentlogger-purplecomet" 

Aplicacion de escritorio pensada para su uso en equipos Windows, con el objetivo de registrar las pulsaciones del teclado del usuario, como tambien las ventanas en las que esto ocurre, junto con hora y fecha.

El sistema posee un inicio de sesion el cual se conecta al proyecto webpage-purplecomet por medio web. La direccion a la cual el programa intentara conectarse es editable por medio del archivo de persistencia que se genera al abrir la aplicacion (ubicado en ../Mis Documentos/Purplecomet/persistence.conf), como tambien otras configuraciones del sistema. Una vez validadas las credenciales, se muestra informacion pertinente al usuario (nombre, empresa, horario) y un boton que inicia o detiene el registro de datos. 

Los datos registrados se guardan temporalmente en buffers locales ubicados en la carpeta ../Mis Documentos/Purplecomet/ antes de ser enviados al servidor. Tras ser confirmada la transferencia, se eliminan localmente.

El sistema posee un sistema de persistencia que recuerda las preferencias y credenciales del usuario. Existen caracteristicas vestigiales que no se implementaron pero se mencionan dentro de la interfaz (inicio con windows, inicio automatico segun hora) los cuales se pueden expandir.

Desarrollado en .NET Framework 4.5, 2020
