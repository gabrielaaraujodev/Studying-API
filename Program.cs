// Vari�vel que vai ser utilizada para fazer a adi��o e configura��o.
var builder = WebApplication.CreateBuilder(args);

//Adiciona os controlers criados.
builder.Services.AddControllers();

// Faz uma adi��o dos Endpoints
builder.Services.AddEndpointsApiExplorer();

// Faz adi��o de um arquivo para o browser ler o Swagger e faze-lo funcionar
builder.Services.AddSwaggerGen();

// FOI CRIADO (n�o vem pronto) par que a minha URL possua letra min�scula
builder.Services.AddRouting(option => option.LowercaseUrls = true);

// Faz o biuld ("compila��o") de todas as configura��es feitas acima.
var app = builder.Build();

// Verificando se estamos executando a API em modo DEBUG, caso TRUE, executar� o Swagger no browser.
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
