using Microsoft.EntityFrameworkCore;
using BookInfoApi.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. 컨트롤러 추가
builder.Services.AddControllers();

// 2. Swagger(API 테스트 화면) 설정 추가
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 3. DB 연결 설정 추가
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// 4. 개발/운영 상관없이 무조건 Swagger 실행하도록 설정
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();
app.Run();