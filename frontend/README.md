
# QuikTix Frontend Setup

## Install CORS
To enable cross-origin requests in your backend, install the CORS package by running:
```bash
dotnet add package Microsoft.AspNetCore.Cors
```
This allows the backend to handle requests from different origins, a requirement for many frontend-backend integrations.

## Install Dependencies
To set up your frontend project, install necessary dependencies with:
```bash
npm install
```
This command downloads and sets up all packages listed in the `package.json` file, ensuring your frontend application has everything it needs to run.

## Serve Static Files
To host your frontend locally, use the following command:
```bash
http-server
```
If CORS is disabled by default and you need to enable it, use:
```bash
http-server --cors
```
This starts a local HTTP server to serve your static files. It also handles cross-origin requests if `--cors` is specified.

## Open the Application
You can access your frontend application in one of two ways:
- Use the **Live Server** extension in Visual Studio Code to launch the application in your default browser.
- Copy the link generated by the HTTP server and open it in your browser.

By following these steps, you can successfully set up and run your QuikTix frontend application.
