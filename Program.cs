// Variável que vai ser utilizada para fazer a adição e configuração.
var builder = WebApplication.CreateBuilder(args);

//Adiciona os controlers criados.
builder.Services.AddControllers();

// Faz uma adição dos Endpoints
builder.Services.AddEndpointsApiExplorer();

// Faz adição de um arquivo para o browser ler o Swagger e faze-lo funcionar
builder.Services.AddSwaggerGen();

// FOI CRIADO (não vem pronto) par que a minha URL possua letra minúscula
builder.Services.AddRouting(option => option.LowercaseUrls = true);

// Faz o biuld ("compilação") de todas as configurações feitas acima.
var app = builder.Build();

// Verificando se estamos executando a API em modo DEBUG, caso TRUE, executará o Swagger no browser.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Redireciona a API para utilizar HTTPS.
app.UseHttpsRedirection();


//
app.UseAuthorization();


// Vai fazer o mapeamento dos controles que possuimos depois de adiciona-los acima.
app.MapControllers();


// Vai fazer a API rodar.
app.Run();
