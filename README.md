# Proyecto de Gestión Médica

Este proyecto tiene como objetivo gestionar los datos de pacientes y usuarios en un entorno clínico. El sistema proporciona funcionalidades para la autenticación, gestión de perfiles, y administración de historias clínicas y procedimientos médicos.

## Requerimientos Funcionales

| Código | Nombre                | Categoría             | Descripción                                                                                              | Prioridad |
|--------|-----------------------|-----------------------|----------------------------------------------------------------------------------------------------------|-----------|
| RF-01  | Iniciar sesión        | Autenticar Usuario    | El sistema debe permitir que los administradores y trabajadores inicien sesión con sus credenciales correspondientes. | Alta      |
| RF-02  | Ver perfil            | Gestionar Perfil      | El sistema debe permitir a los usuarios ver y actualizar su perfil personal.                              | Baja      |
| RF-03  | Gestionar usuarios    | Gestionar Usuarios    | El sistema debe permitir a los administradores gestionar los datos y roles de los usuarios pertenecientes a la empresa. | Alta      |
| RF-04  | Gestionar Historia Clínica | Gestionar Historia Clínica | El sistema debe permitir a los usuarios gestionar los datos de los pacientes, así como sus antecedentes y referencias familiares. | Alta      |
| RF-05  | Gestionar Pacientes   | Gestionar Pacientes   | El sistema debe permitir a los usuarios (doctores, auxiliar, asistente) gestionar (crear, editar y ver) los datos de los pacientes en el sistema. | Alta      |
| RF-06  | Gestionar Procedimientos | Gestionar Procedimientos | El sistema debe permitir a los usuarios (doctores, auxiliar, asistente) registrar procedimientos que el personal le realizó al paciente. | Alta      |
| RF-07  | Visualizar Historial  | Consultar Historial   | El sistema debe permitir a los trabajadores consultar el historial médico de los pacientes, así como los procedimientos generados. | Media     |

## Instalación

Para instalar y configurar el proyecto, sigue estos pasos:

1. Clona el repositorio: `git clone https://github.com/tu_usuario/tu_repositorio.git`
2. Instala las dependencias: `npm install`
3. Configura las variables de entorno según tus necesidades.

## Uso

Para iniciar la aplicación, ejecuta:

```bash
npm start
