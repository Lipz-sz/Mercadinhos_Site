Configurar DbContext
https://chatgpt.com/s/t_69e932448818819183b94cb058242683


Opções do SQLite
https://chatgpt.com/s/t_69e92d76cb9881918e56822af3844610

# Guia Básico de EF Core com SQLite e Swagger

## 📦 Configuração do DbContext

```csharp
builder.Services.AddDbContext<UserContext>(opt =>
    opt.UseSqlite("Data Source=dataBase.db"));

🧠 O que é DbSet
public DbSet<Post> Posts { get; set; }
Representa uma tabela no banco
Permite CRUD (Create, Read, Update, Delete)
É essencial para persistência de dados


🔗 Relacionamentos

✅ One-to-One
modelBuilder.Entity<User>()
    .HasOne(u => u.Profile)
    .WithOne(p => p.User)
    .HasForeignKey<Profile>(p => p.UserId);


✅ One-to-Many
modelBuilder.Entity<User>()
    .HasMany(u => u.Posts)
    .WithOne(p => p.User)
    .HasForeignKey(p => p.UserId);

✅ Many-to-Many
modelBuilder.Entity<User>()
    .HasMany(u => u.Roles)
    .WithMany(r => r.Users);


💾 Operações no banco

➕ Adicionar
context.Users.Add(user);
await context.SaveChangesAsync();

✏️ Atualizar
context.Users.Update(user);
await context.SaveChangesAsync();

❌ Remover
context.Users.Remove(user);
await context.SaveChangesAsync();

🔍 Buscar
var users = await context.Users.ToListAsync();

Com relacionamento:
var users = await context.Users
    .Include(u => u.Posts)
    .ToListAsync();


⚙️ Opções do UseSqlite
opt.UseSqlite("Data Source=dataBase.db", sqliteOptions =>
{
    sqliteOptions.CommandTimeout(30);
    sqliteOptions.EnableRetryOnFailure();
});
🔌 Connection String

Exemplos:

Data Source=data.db
Data Source=data.db;Foreign Keys=True
Data Source=:memory:
Data Source=data.db;Cache=Shared

⚙️ Configurações adicionais
Log
opt.LogTo(Console.WriteLine);
Erros detalhados
opt.EnableDetailedErrors();
opt.EnableSensitiveDataLogging();

🔄 Migrações
dotnet ef migrations add InitialCreate
dotnet ef database update

⚠️ Boas práticas
Sempre usar SaveChanges()
Usar Include() para relacionamentos
Definir chaves estrangeiras corretamente
Criar DbSet para entidades principais

🚀 Exemplo completo
builder.Services.AddDbContext<UserContext>(opt =>
    opt.UseSqlite("Data Source=dataBase.db;Foreign Keys=True", sqliteOptions =>
    {
        sqliteOptions.CommandTimeout(30);
        sqliteOptions.EnableRetryOnFailure();
    })
    .EnableDetailedErrors()
    .EnableSensitiveDataLogging()
    .LogTo(Console.WriteLine)
);