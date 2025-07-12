# MyProxy

A lightweight HTTP proxy service built with ASP.NET Core 8.0 that forwards HTTP requests to specified URLs.

## Features

- Forward HTTP GET requests to specified URLs
- Simple API for testing and integration
- Docker support for containerized deployment
- Swagger UI for API documentation and testing

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Docker (optional, for containerized deployment)

### Running Locally

1. Clone the repository
2. Navigate to the project directory
```bash
cd MyProxy
```
3. Run the application
```bash
dotnet run --project MyProxy
```
4. The application will start on the configured port (check appsettings.json)

### Docker Deployment

1. Build the Docker image
```bash
docker build -t myproxy:latest .
```
2. Run the container
```bash
docker run -p 8000:8000 myproxy:latest
```

## Usage

### Testing the Proxy

To check if the proxy is working:
```
GET /myproxy/test
```
Expected response: "MyProxy Works!"

### Making Proxy Requests

To proxy a request through the service:
```
GET /myproxy
X-Forward-Url: https://example.com
```

The proxy will:
1. Forward your request to the URL specified in the `X-Forward-Url` header
2. Return the response from the target URL

## Configuration

The application uses standard ASP.NET Core configuration patterns. Key settings:

- HTTP port: Configured in the `Ports:Http` section of appsettings.json

## Development

The solution includes:
- ASP.NET Core 8.0 Web API project
- Docker support with a Linux target OS
- Swagger/OpenAPI integration

## License

This project is licensed under the MIT License - see the LICENSE file for details.
