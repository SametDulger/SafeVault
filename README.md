# SafeVault - Secure Authentication API

A robust and secure authentication API built with ASP.NET Core 9, featuring JWT token-based authentication, ASP.NET Core Identity, and comprehensive security measures. SafeVault provides a solid foundation for secure user management in modern web applications.

## 🔐 Project Overview

SafeVault is a production-ready authentication service that implements industry-standard security practices. It provides user registration, login, and logout functionality with JWT token authentication, password policies, and secure session management. Built with ASP.NET Core 9 and Entity Framework Core, it offers a scalable and maintainable authentication solution.

## ✨ Features

### 🔑 Authentication & Authorization
- **JWT Token Authentication** - Secure token-based authentication system
- **User Registration** - Secure account creation with validation
- **User Login** - Secure login with password verification
- **User Logout** - Secure session termination
- **Role-Based Authorization** - Support for user roles and permissions
- **Password Policies** - Enforced password complexity requirements

### 🛡️ Security Features
- **Password Hashing** - Secure password storage using ASP.NET Core Identity
- **JWT Token Security** - Configurable token expiration and validation
- **Input Validation** - Comprehensive model validation and sanitization
- **HTTPS Enforcement** - Secure communication protocols
- **CORS Configuration** - Cross-origin resource sharing security
- **HTML Sanitization** - Protection against XSS attacks

### 🏗️ Architecture & Design
- **Clean Architecture** - Separation of concerns with controllers, services, and models
- **Dependency Injection** - Modern .NET dependency injection patterns
- **Entity Framework Core** - Modern ORM with InMemory database support
- **RESTful API Design** - Standard REST API endpoints
- **Swagger Documentation** - Interactive API documentation

### 🔧 Development Features
- **Swagger UI** - Interactive API testing and documentation
- **InMemory Database** - Development-friendly database option
- **Configuration Management** - Environment-based configuration
- **Logging** - Structured logging with configurable levels
- **Error Handling** - Comprehensive error responses

## 🛠️ Technologies Used

### Core Framework
- **ASP.NET Core 9** - Modern web framework for building APIs
- **Entity Framework Core 9.0.6** - Object-relational mapping
- **ASP.NET Core Identity 9.0.6** - User management and authentication

### Authentication & Security
- **JWT Bearer Authentication 9.0.6** - JSON Web Token implementation
- **HTML Sanitizer 9.0.886** - XSS protection and input sanitization
- **Microsoft Identity Model** - Security token handling

### Database & Storage
- **Entity Framework InMemory** - In-memory database for development
- **SQL Server Support** - Production database compatibility
- **Entity Framework Tools** - Database migration and management

### Development Tools
- **Swashbuckle.AspNetCore 9.0.1** - Swagger/OpenAPI documentation
- **Microsoft.AspNetCore.OpenApi 9.0.6** - OpenAPI integration
- **Entity Framework Tools** - Database development tools

## 🚀 Getting Started

### Prerequisites
- **.NET 9 SDK** - Latest .NET 9 runtime and SDK
- **Visual Studio 2022** or **VS Code** - Development environment
- **Postman** or **curl** - API testing tools

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/SametDulger/SafeVault.git
   cd SafeVault
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Configure environment**
   - Update `appsettings.json` with your JWT secret key
   - Configure database connection strings for production

4. **Run the application**
   ```bash
   dotnet run
   ```

5. **Access the application**
   - **API**: `https://localhost:7134` (HTTPS) or `http://localhost:5134` (HTTP)
   - **Swagger UI**: `https://localhost:7134/swagger`

## 📁 Project Structure

```
SafeVault/
├── Controllers/                 # API Controllers
│   └── AuthController.cs       # Authentication endpoints
├── Data/                       # Data Access Layer
│   ├── ApplicationDbContext.cs # Entity Framework context
│   └── DataSeeder.cs          # Database seeding utilities
├── Models/                     # Data Models
│   ├── LoginModel.cs          # Login request model
│   └── RegisterModel.cs       # Registration request model
├── Services/                   # Business Logic Services
│   └── TokenService.cs        # JWT token generation service
├── Properties/                 # Project properties
├── Program.cs                  # Application entry point
├── SafeVault.csproj           # Project file
├── appsettings.json           # Configuration settings
└── README.md                  # Project documentation
```

## 🔌 API Endpoints

### Authentication Endpoints

#### User Registration
```http
POST /api/auth/register
Content-Type: application/json

{
  "username": "john_doe",
  "email": "john@example.com",
  "password": "SecurePass123!",
  "confirmPassword": "SecurePass123!"
}
```

**Response:**
```json
{
  "message": "User registered successfully."
}
```

#### User Login
```http
POST /api/auth/login
Content-Type: application/json

{
  "username": "john_doe",
  "password": "SecurePass123!"
}
```

**Response:**
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}
```

#### User Logout
```http
POST /api/auth/logout
Authorization: Bearer {token}
```

**Response:**
```json
{
  "message": "User logged out successfully."
}
```

## 📊 Data Models

### RegisterModel
```csharp
public class RegisterModel
{
    [Required]
    [MinLength(3)]
    public string Username { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength(6)]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&]).+$")]
    public string Password { get; set; }

    [Required]
    [Compare("Password")]
    public string ConfirmPassword { get; set; }
}
```

### LoginModel
```csharp
public class LoginModel
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}
```

## 🔧 Configuration

### JWT Settings
```json
{
  "JwtSettings": {
    "Secret": "your-super-secret-jwt-key-here"
  }
}
```

### Password Policy
- **Minimum Length**: 8 characters
- **Require Digit**: Yes
- **Require Uppercase**: Yes
- **Require Lowercase**: Yes
- **Require Special Character**: No (configurable)

### Token Configuration
- **Expiration**: 1 hour (configurable)
- **Algorithm**: HMAC SHA256
- **Issuer/Audience**: Configurable for production

## 🧪 Testing

### Using Swagger UI
1. Navigate to `https://localhost:7134/swagger`
2. Test endpoints directly in the browser
3. View request/response schemas
4. Execute API calls with sample data

### Using HTTP Files
```bash
# Test registration
curl -X POST "https://localhost:7134/api/auth/register" \
  -H "Content-Type: application/json" \
  -d '{"username":"testuser","email":"test@example.com","password":"TestPass123!","confirmPassword":"TestPass123!"}'

# Test login
curl -X POST "https://localhost:7134/api/auth/login" \
  -H "Content-Type: application/json" \
  -d '{"username":"testuser","password":"TestPass123!"}'
```

### Using Postman
1. Import the API endpoints
2. Set up environment variables
3. Test authentication flow
4. Validate JWT tokens

## 🚀 Deployment

### Development Deployment
```bash
dotnet run --environment Development
```

### Production Deployment
```bash
# Build for production
dotnet publish -c Release

# Run with production configuration
dotnet run --environment Production
```

### Docker Deployment
```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["SafeVault.csproj", "./"]
RUN dotnet restore "SafeVault.csproj"
COPY . .
RUN dotnet build "SafeVault.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SafeVault.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SafeVault.dll"]
```

## 🔒 Security Considerations

### Production Security
- **Change JWT Secret**: Use a strong, unique secret key
- **Enable HTTPS**: Configure SSL certificates
- **Database Security**: Use secure database connections
- **Environment Variables**: Store secrets in environment variables
- **CORS Policy**: Configure appropriate CORS policies
- **Rate Limiting**: Implement API rate limiting
- **Audit Logging**: Add comprehensive audit trails

### Security Best Practices
- **Password Policies**: Enforce strong password requirements
- **Token Expiration**: Set appropriate token lifetimes
- **Input Validation**: Validate and sanitize all inputs
- **Error Handling**: Avoid information disclosure in errors
- **Regular Updates**: Keep dependencies updated

## 🤝 Contributing

1. **Fork the repository**
2. **Create a feature branch** (`git checkout -b feature/amazing-feature`)
3. **Commit your changes** (`git commit -m 'Add some amazing feature'`)
4. **Push to the branch** (`git push origin feature/amazing-feature`)
5. **Open a Pull Request**

### Development Guidelines
- Follow C# coding conventions
- Add unit tests for new features
- Update documentation as needed
- Ensure security best practices
- Test thoroughly before submitting

## 🔮 Future Enhancements

### Planned Features
- **Email Verification** - Email confirmation for registration
- **Password Reset** - Secure password recovery functionality
- **Two-Factor Authentication** - Enhanced security with 2FA
- **Social Login** - OAuth integration (Google, Facebook, etc.)
- **User Profiles** - Extended user profile management
- **Audit Logging** - Comprehensive activity tracking

### Technical Improvements
- **Redis Caching** - Performance optimization
- **Database Migrations** - Production database setup
- **Health Checks** - Application health monitoring
- **API Versioning** - Version control for API endpoints
- **Rate Limiting** - API usage throttling
- **Monitoring & Analytics** - Application insights

## 📝 License

This project is licensed under the **MIT License** - see the [LICENSE](LICENSE) file for details.

## 🙏 Acknowledgments

- **Microsoft ASP.NET Core Team** - Excellent web framework
- **Entity Framework Team** - Powerful ORM solution
- **JWT.io** - JSON Web Token standards
- **OpenAPI/Swagger Team** - API documentation tools

## 📚 Learning Resources

### Documentation
- [ASP.NET Core Documentation](https://docs.microsoft.com/en-us/aspnet/core/)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [ASP.NET Core Identity](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity)
- [JWT Authentication](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/jwt-auth)

### Tutorials
- [Building Web APIs with ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/web-api/)
- [Secure ASP.NET Core Web API](https://docs.microsoft.com/en-us/aspnet/core/security/)
- [JWT Token Best Practices](https://auth0.com/blog/a-look-at-the-latest-draft-for-jwt-bcp/)

## 📞 Support

For questions, issues, or contributions:
- **Issues**: [GitHub Issues](https://github.com/SametDulger/SafeVault/issues)
- **Discussions**: [GitHub Discussions](https://github.com/SametDulger/SafeVault/discussions)

## 🌟 Key Highlights

### Security-First Design
- **JWT Authentication** - Industry-standard token-based auth
- **Password Security** - Strong password policies and hashing
- **Input Validation** - Comprehensive validation and sanitization
- **HTTPS Enforcement** - Secure communication protocols

### Modern Architecture
- **ASP.NET Core 9** - Latest .NET framework features
- **Clean Architecture** - Separation of concerns
- **Dependency Injection** - Modern .NET patterns
- **RESTful Design** - Standard API conventions

### Developer Experience
- **Swagger Documentation** - Interactive API testing
- **InMemory Database** - Easy development setup
- **Comprehensive Logging** - Debugging and monitoring
- **Production Ready** - Scalable and maintainable

---

**Built with ❤️ using ASP.NET Core 9, Entity Framework Core, and JWT Authentication**
