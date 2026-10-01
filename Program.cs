var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors();

// ============================================================================
// 1. DATOS DE HORARIOS, RESERVAS Y DISPONIBILIDAD DE CANCHAS DE FÚTBOL
// ============================================================================
var canchasHorarios = new List<CanchaHorario>
{
    new CanchaHorario
    {
        Id = 1,
        Codigo = "CAN-001",
        Nombre = "Cancha Monumental FIFA Pro #1",
        TipoCancha = "Fútbol 7",
        Servicio = "Alquiler de cancha",
        Categoria = "Alquiler Nocturno",
        Fecha = "2026-10-01",
        Hora = "19:00 - 20:00",
        Turno = "Noche",
        Duracion = "60 minutos",
        Estado = "Disponible",
        Disponibilidad = true,
        Precio = 120.00,
        Descuento = 0,
        Promocion = "Incluye chalecos + balón oficial",
        Capacidad = "14 jugadores (7 vs 7)",
        Gramado = "Grass Sintético FIFA Quality Pro 60mm",
        ServiciosIncluidos = new[] { "Iluminación LED 500W", "Vestuarios y Duchas", "Estacionamiento Privado", "Marcador Electrónico" },
        Imagen = "https://images.unsplash.com/photo-1529900748604-07564a03e7a6?w=900&auto=format&fit=crop&q=80",
        Detalle = "Cancha principal de Fútbol 7 con caucho criogénico antideslizante, malla perimetral de seguridad completa y reflectores LED de estadio sin deslumbramiento."
    },
    new CanchaHorario
    {
        Id = 2,
        Codigo = "CAN-002",
        Nombre = "Cancha Monumental FIFA Pro #1",
        TipoCancha = "Fútbol 7",
        Servicio = "Alquiler de cancha",
        Categoria = "Alquiler Nocturno",
        Fecha = "2026-10-01",
        Hora = "20:00 - 21:00",
        Turno = "Noche",
        Duracion = "60 minutos",
        Estado = "Reservado",
        Disponibilidad = false,
        Precio = 130.00,
        Descuento = 0,
        Promocion = "Horario Prime Estelar",
        Capacidad = "14 jugadores (7 vs 7)",
        Gramado = "Grass Sintético FIFA Quality Pro 60mm",
        ServiciosIncluidos = new[] { "Iluminación LED 500W", "Vestuarios y Duchas", "Estacionamiento Privado" },
        Imagen = "https://images.unsplash.com/photo-1575361204480-aadea25e6e68?w=900&auto=format&fit=crop&q=80",
        Detalle = "Turno estelar de las 8:00 PM actualmente reservado por Liga Amateur San Isidro. Cuenta con tribuna techada para 40 espectadores."
    },
    new CanchaHorario
    {
        Id = 3,
        Codigo = "CAN-003",
        Nombre = "Cancha La Bombonera Techada #2",
        TipoCancha = "Fútbol 6",
        Servicio = "Alquiler de cancha",
        Categoria = "Happy Hour Tarde",
        Fecha = "2026-10-01",
        Hora = "16:00 - 17:00",
        Turno = "Tarde",
        Duracion = "60 minutos",
        Estado = "Disponible",
        Disponibilidad = true,
        Precio = 90.00,
        Descuento = 20,
        Promocion = "20% OFF Promo Tarde Deportiva",
        Capacidad = "12 jugadores (6 vs 6)",
        Gramado = "Grass Sintético Monofilamento Europeo",
        ServiciosIncluidos = new[] { "Techo Parabólico UV", "Vestuarios", "Estacionamiento", "Hidratación Básica" },
        Imagen = "https://images.unsplash.com/photo-1518604666860-9ed391f76460?w=900&auto=format&fit=crop&q=80",
        Detalle = "Cancha techada con cobertura metálica contra sol y lluvia. Ideal para partidos rápidos de 6 contra 6 por la tarde con tarifa promocional."
    },
    new CanchaHorario
    {
        Id = 4,
        Codigo = "CAN-004",
        Nombre = "Arena Champions Oficial #3",
        TipoCancha = "Fútbol 8",
        Servicio = "Alquiler de cancha",
        Categoria = "Alquiler Nocturno",
        Fecha = "2026-10-01",
        Hora = "21:00 - 22:30",
        Turno = "Noche",
        Duracion = "90 minutos",
        Estado = "Disponible",
        Disponibilidad = true,
        Precio = 165.00,
        Descuento = 10,
        Promocion = "10% OFF Pack 90 Minutos",
        Capacidad = "16 jugadores (8 vs 8)",
        Gramado = "Grass Sintético Híbrido Amortiguado",
        ServiciosIncluidos = new[] { "Iluminación LED 600W", "Vestuarios VIP", "Estacionamiento", "Cámara de Repetición Gol" },
        Imagen = "https://images.unsplash.com/photo-1459865264687-595d652de67e?w=900&auto=format&fit=crop&q=80",
        Detalle = "Campo amplio reglamentario para Fútbol 8 en formato de 90 minutos. Incluye acceso a cámaras de grabación de jugadas y banca de suplentes techada."
    },
    new CanchaHorario
    {
        Id = 5,
        Codigo = "CAN-005",
        Nombre = "Estadio Central Arena Golazo #4",
        TipoCancha = "Fútbol 11",
        Servicio = "Campeonatos",
        Categoria = "Torneos y Ligas",
        Fecha = "2026-10-02",
        Hora = "18:00 - 20:00",
        Turno = "Noche",
        Duracion = "120 minutos",
        Estado = "Disponible",
        Disponibilidad = true,
        Precio = 280.00,
        Descuento = 15,
        Promocion = "15% OFF Especial Campeonatos",
        Capacidad = "22 jugadores (11 vs 11)",
        Gramado = "Grass Sintético Profesional FIFA 11",
        ServiciosIncluidos = new[] { "Iluminación Estadio 8 Torres", "2 Vestuarios Completos", "Estacionamiento 30 Autos", "Mesa de Control y Sonido" },
        Imagen = "https://images.unsplash.com/photo-1508098682722-e99c43a406b2?w=900&auto=format&fit=crop&q=80",
        Detalle = "Campo oficial de Fútbol 11 diseñado para campeonatos relámpago, ligas empresariales y finales universitarias. Incluye 2 camerinos independientes y mesa arbitral."
    },
    new CanchaHorario
    {
        Id = 6,
        Codigo = "CAN-006",
        Nombre = "Cancha Formación Academia #2",
        TipoCancha = "Fútbol 7",
        Servicio = "Entrenamientos",
        Categoria = "Academia y Entrenamiento",
        Fecha = "2026-10-02",
        Hora = "09:00 - 11:00",
        Turno = "Mañana",
        Duracion = "120 minutos",
        Estado = "Disponible",
        Disponibilidad = true,
        Precio = 110.00,
        Descuento = 25,
        Promocion = "25% OFF Tarifa Mañana Entrenamiento",
        Capacidad = "14 a 20 alumnos",
        Gramado = "Grass Sintético Monofilamento",
        ServiciosIncluidos = new[] { "Conos, Vallas y Escalera Coordinación", "Vestuarios", "Estacionamiento", "5 Balones de Entrenamiento" },
        Imagen = "https://images.unsplash.com/photo-1526232761682-d26e03ac148e?w=900&auto=format&fit=crop&q=80",
        Detalle = "Horario matutino especial para entrenamientos tácticos, escuelas de menores o preparación física de equipos con kit completo de entrenamiento incluido."
    },
    new CanchaHorario
    {
        Id = 7,
        Codigo = "CAN-007",
        Nombre = "Arena Champions Oficial #3",
        TipoCancha = "Fútbol 8",
        Servicio = "Eventos",
        Categoria = "Eventos Corporativos",
        Fecha = "2026-10-03",
        Hora = "14:00 - 18:00",
        Turno = "Tarde",
        Duracion = "240 minutos",
        Estado = "Disponible",
        Disponibilidad = true,
        Precio = 420.00,
        Descuento = 15,
        Promocion = "Pack Integración Empresarial + Zona Parrilla",
        Capacidad = "Hasta 60 asistentes",
        Gramado = "Grass Sintético Híbrido Amortiguado",
        ServiciosIncluidos = new[] { "Alquiler de Cancha 4h", "Zona Lounge & Parrilla", "Sonido Ambiental", "Estacionamiento Privado", "Vestuarios" },
        Imagen = "https://images.unsplash.com/photo-1551958219-acbc608c6377?w=900&auto=format&fit=crop&q=80",
        Detalle = "Paquete integral para eventos deportivos corporativos, cumpleaños futboleros o confraternidad de empresas con acceso exclusivo a terraza y zona de parrillas."
    },
    new CanchaHorario
    {
        Id = 8,
        Codigo = "CAN-008",
        Nombre = "Cancha La Bombonera Techada #2",
        TipoCancha = "Fútbol 6",
        Servicio = "Alquiler de cancha",
        Categoria = "Alquiler Nocturno",
        Fecha = "2026-10-02",
        Hora = "20:00 - 21:00",
        Turno = "Noche",
        Duracion = "60 minutos",
        Estado = "Disponible",
        Disponibilidad = true,
        Precio = 115.00,
        Descuento = 0,
        Promocion = "Cancha Techada + Iluminación LED",
        Capacidad = "12 jugadores (6 vs 6)",
        Gramado = "Grass Sintético Monofilamento Europeo",
        ServiciosIncluidos = new[] { "Iluminación LED", "Techo Parabólico", "Vestuarios", "Estacionamiento" },
        Imagen = "https://images.unsplash.com/photo-1574629810360-7efbbe195018?w=900&auto=format&fit=crop&q=80",
        Detalle = "Turno nocturno en cancha 100% techada con ventilación cruzada y tableros laterales para un juego dinámico e ininterrumpido."
    },
    new CanchaHorario
    {
        Id = 9,
        Codigo = "CAN-009",
        Nombre = "Estadio Central Arena Golazo #4",
        TipoCancha = "Fútbol 11",
        Servicio = "Campeonatos",
        Categoria = "Torneos y Ligas",
        Fecha = "2026-10-03",
        Hora = "20:00 - 22:00",
        Turno = "Noche",
        Duracion = "120 minutos",
        Estado = "Reservado",
        Disponibilidad = false,
        Precio = 320.00,
        Descuento = 0,
        Promocion = "Final Copa Universitaria",
        Capacidad = "22 jugadores (11 vs 11)",
        Gramado = "Grass Sintético Profesional FIFA 11",
        ServiciosIncluidos = new[] { "Iluminación Estadio", "Terna Arbitral", "Vestuarios VIP", "Estacionamiento" },
        Imagen = "https://images.unsplash.com/photo-1522778119026-d647f0596c20?w=900&auto=format&fit=crop&q=80",
        Detalle = "Reserva confirmada para encuentro nocturno de Fútbol 11 con iluminación profesional de 8 torres."
    },
    new CanchaHorario
    {
        Id = 10,
        Codigo = "CAN-010",
        Nombre = "Cancha Monumental FIFA Pro #1",
        TipoCancha = "Fútbol 7",
        Servicio = "Entrenamientos",
        Categoria = "Academia y Entrenamiento",
        Fecha = "2026-10-03",
        Hora = "10:00 - 11:30",
        Turno = "Mañana",
        Duracion = "90 minutos",
        Estado = "Disponible",
        Disponibilidad = true,
        Precio = 95.00,
        Descuento = 20,
        Promocion = "20% OFF Sábado por la Mañana",
        Capacidad = "14 jugadores (7 vs 7)",
        Gramado = "Grass Sintético FIFA Quality Pro 60mm",
        ServiciosIncluidos = new[] { "Chalecos y Balones", "Vestuarios con Duchas", "Estacionamiento" },
        Imagen = "https://images.unsplash.com/photo-1431324155629-1a6deb1dec8d?w=900&auto=format&fit=crop&q=80",
        Detalle = "Turno matutino de fin de semana ideal para partidos amistosos y entrenamientos de equipos con tarifa reducida."
    }
};

// ============================================================================
// 2. CATÁLOGO DE SERVICIOS OFRECIDOS POR EL COMPLEJO DEPORTIVO
// ============================================================================
var serviciosComplejo = new List<ServicioDeportivo>
{
    new ServicioDeportivo
    {
        Id = 1,
        Codigo = "SRV-01",
        Nombre = "Alquiler de Canchas (Fútbol 6, 7, 8 y 11)",
        Categoria = "Principal",
        Precio = 90.00,
        Unidad = "Desde S/ 90 / hora",
        Disponibilidad = "Lunes a Domingo (07:00 - 23:30)",
        Icono = "⚽",
        Destacado = true,
        Imagen = "https://images.unsplash.com/photo-1529900748604-07564a03e7a6?w=700&auto=format&fit=crop&q=80",
        Descripcion = "4 campos de grass sintético certificado FIFA Quality Pro con absorción de impacto, mallas perimetrales nuevas, chalecos limpios y balones oficiales incluidos en cada turno."
    },
    new ServicioDeportivo
    {
        Id = 2,
        Codigo = "SRV-02",
        Nombre = "Organización de Campeonatos y Ligas",
        Categoria = "Torneos",
        Precio = 280.00,
        Unidad = "Paquetes por Fecha o Torneo",
        Disponibilidad = "Fines de Semana y Noches",
        Icono = "🏆",
        Destacado = true,
        Imagen = "https://images.unsplash.com/photo-1508098682722-e99c43a406b2?w=700&auto=format&fit=crop&q=80",
        Descripcion = "Servicio integral para campeonatos relámpago, inter-empresas y universitarios: incluye mesa de control, sonido en vivo, arbitraje federado, trofeos y marcador digital."
    },
    new ServicioDeportivo
    {
        Id = 3,
        Codigo = "SRV-03",
        Nombre = "Entrenamientos y Academias Deportivas",
        Categoria = "Formación",
        Precio = 95.00,
        Unidad = "Tarifa Especial Mañana/Tarde",
        Disponibilidad = "Lunes a Sábado (07:00 - 17:00)",
        Icono = "🏃",
        Destacado = true,
        Imagen = "https://images.unsplash.com/photo-1526232761682-d26e03ac148e?w=700&auto=format&fit=crop&q=80",
        Descripcion = "Espacios equipados con conos, vallas pliométricas, escaleras de coordinación, arcos móviles y balones para entrenamientos de clubes y escuelas de fútbol."
    },
    new ServicioDeportivo
    {
        Id = 4,
        Codigo = "SRV-04",
        Nombre = "Eventos Corporativos y Cumpleaños",
        Categoria = "Eventos",
        Precio = 420.00,
        Unidad = "Pack 4 Horas + Zona Parrilla",
        Disponibilidad = "Viernes, Sábados y Domingos",
        Icono = "🎉",
        Destacado = true,
        Imagen = "https://images.unsplash.com/photo-1551958219-acbc608c6377?w=700&auto=format&fit=crop&q=80",
        Descripcion = "Reserva combinada de canchas con nuestra terraza lounge, zona de parrillas equipada, música ambiental y atención personalizada para empresas y celebraciones."
    },
    new ServicioDeportivo
    {
        Id = 5,
        Codigo = "SRV-05",
        Nombre = "Vestuarios VIP y Duchas Termostatizadas",
        Categoria = "Comodidades",
        Precio = 0.00,
        Unidad = "Incluido con tu reserva",
        Disponibilidad = "Permanente",
        Icono = "🚿",
        Destacado = false,
        Imagen = "https://images.unsplash.com/photo-1574629810360-7efbbe195018?w=700&auto=format&fit=crop&q=80",
        Descripcion = "Camerinos amplios e higienizados con casilleros de seguridad (lockers), bancas ergonómicas y duchas de agua caliente de alta presión."
    },
    new ServicioDeportivo
    {
        Id = 6,
        Codigo = "SRV-06",
        Nombre = "Iluminación LED Profesional de Estadio",
        Categoria = "Infraestructura",
        Precio = 0.00,
        Unidad = "Incluido en turnos nocturnos",
        Disponibilidad = "18:00 - 23:30 hrs",
        Icono = "💡",
        Destacado = false,
        Imagen = "https://images.unsplash.com/photo-1459865264687-595d652de67e?w=700&auto=format&fit=crop&q=80",
        Descripcion = "Torres de iluminación LED asimétrica de 500W y 600W que garantizan visibilidad uniforme de día y de noche sin encandilar a los jugadores."
    },
    new ServicioDeportivo
    {
        Id = 7,
        Codigo = "SRV-07",
        Nombre = "Estacionamiento Privado y Vigilado",
        Categoria = "Seguridad",
        Precio = 0.00,
        Unidad = "Gratuito para clientes (50 cocheras)",
        Disponibilidad = "Videovigilancia 24/7",
        Icono = "🚗",
        Destacado = false,
        Imagen = "https://images.unsplash.com/photo-1518604666860-9ed391f76460?w=700&auto=format&fit=crop&q=80",
        Descripcion = "Amplio estacionamiento interno para 50 vehículos y zona de bicicletas/motos con cámaras de seguridad HD y personal de vigilancia permanente."
    },
    new ServicioDeportivo
    {
        Id = 8,
        Codigo = "SRV-08",
        Nombre = "Grabación HD de Partidos y Arbitraje",
        Categoria = "Servicios Adicionales",
        Precio = 35.00,
        Unidad = "S/ 35 por partido",
        Disponibilidad = "Bajo solicitud en turno",
        Icono = "🎥",
        Destacado = false,
        Imagen = "https://images.unsplash.com/photo-1575361204480-aadea25e6e68?w=700&auto=format&fit=crop&q=80",
        Descripcion = "Servicio adicional de árbitro oficial acreditado y cámara inteligente que graba los mejores goles y jugadas de tu partido para descargar por enlace."
    }
};

app.MapGet("/", () => "API Arena Golazo - Complejo Deportivo y Alquiler de Canchas de Fútbol funcionando en Render");

// Handler compartido para consultar y filtrar horarios de canchas
Func<string?, string?, string?, string?, string?, double?, string?, IResult> consultarCanchasHandler =
    (string? tipoCancha, string? estado, string? fecha, string? turno, string? servicio, double? precioMax, string? buscar) =>
{
    IEnumerable<CanchaHorario> query = canchasHorarios;

    if (!string.IsNullOrWhiteSpace(tipoCancha) && !tipoCancha.Equals("Todos", StringComparison.OrdinalIgnoreCase))
        query = query.Where(c => c.TipoCancha.Equals(tipoCancha.Trim(), StringComparison.OrdinalIgnoreCase));

    if (!string.IsNullOrWhiteSpace(estado) && !estado.Equals("Todos", StringComparison.OrdinalIgnoreCase))
        query = query.Where(c => c.Estado.Equals(estado.Trim(), StringComparison.OrdinalIgnoreCase));

    if (!string.IsNullOrWhiteSpace(fecha) && !fecha.Equals("Todas", StringComparison.OrdinalIgnoreCase))
        query = query.Where(c => c.Fecha.Equals(fecha.Trim(), StringComparison.OrdinalIgnoreCase));

    if (!string.IsNullOrWhiteSpace(turno) && !turno.Equals("Todos", StringComparison.OrdinalIgnoreCase))
        query = query.Where(c => c.Turno.Equals(turno.Trim(), StringComparison.OrdinalIgnoreCase));

    if (!string.IsNullOrWhiteSpace(servicio) && !servicio.Equals("Todos", StringComparison.OrdinalIgnoreCase))
        query = query.Where(c => c.Servicio.Equals(servicio.Trim(), StringComparison.OrdinalIgnoreCase));

    if (precioMax.HasValue && precioMax.Value > 0)
        query = query.Where(c => (c.Precio * (1 - c.Descuento / 100.0)) <= precioMax.Value);

    if (!string.IsNullOrWhiteSpace(buscar))
    {
        var q = buscar.Trim();
        query = query.Where(c =>
            c.Nombre.Contains(q, StringComparison.OrdinalIgnoreCase) ||
            c.Codigo.Contains(q, StringComparison.OrdinalIgnoreCase) ||
            c.TipoCancha.Contains(q, StringComparison.OrdinalIgnoreCase) ||
            c.Servicio.Contains(q, StringComparison.OrdinalIgnoreCase) ||
            c.Hora.Contains(q, StringComparison.OrdinalIgnoreCase) ||
            c.Promocion.Contains(q, StringComparison.OrdinalIgnoreCase));
    }

    return Results.Ok(query.ToList());
};

// Rutas principales de la API de Canchas (incluye /api/polleria como alias de compatibilidad)
app.MapGet("/api/canchas", consultarCanchasHandler);
app.MapGet("/api/polleria", consultarCanchasHandler);

// Detalle individual de un horario/cancha por ID
app.MapGet("/api/canchas/{id:int}", (int id) =>
{
    var cancha = canchasHorarios.FirstOrDefault(c => c.Id == id);
    return cancha is not null
        ? Results.Ok(cancha)
        : Results.NotFound(new { message = $"No se encontró el horario de cancha con ID {id}" });
});

// Listado de servicios del complejo deportivo
app.MapGet("/api/servicios", (string? categoria, string? buscar) =>
{
    IEnumerable<ServicioDeportivo> query = serviciosComplejo;

    if (!string.IsNullOrWhiteSpace(categoria) && !categoria.Equals("Todas", StringComparison.OrdinalIgnoreCase))
        query = query.Where(s => s.Categoria.Equals(categoria.Trim(), StringComparison.OrdinalIgnoreCase));

    if (!string.IsNullOrWhiteSpace(buscar))
    {
        var q = buscar.Trim();
        query = query.Where(s =>
            s.Nombre.Contains(q, StringComparison.OrdinalIgnoreCase) ||
            s.Descripcion.Contains(q, StringComparison.OrdinalIgnoreCase) ||
            s.Categoria.Contains(q, StringComparison.OrdinalIgnoreCase));
    }

    return Results.Ok(query.ToList());
});

// Información general del complejo, promociones y User Personas desde la API
app.MapGet("/api/empresa", () =>
{
    return Results.Ok(new
    {
        nombre = "ARENA GOLAZO // COMPLEJO DEPORTIVO",
        eslogan = "Canchas de Grass Sintético Certificado FIFA Quality Pro en Lima",
        ubicacion = "Av. Javier Prado Este 4520, Surco - Lima",
        telefono = "+51 987 654 321",
        horarioGeneral = "Lunes a Domingo de 07:00 AM a 11:30 PM",
        metricas = new
        {
            totalCanchas = 4,
            turnosDisponiblesHoy = canchasHorarios.Count(c => c.Disponibilidad),
            totalHorariosProgramados = canchasHorarios.Count,
            serviciosActivos = serviciosComplejo.Count
        },
        promocionesDestacadas = new[]
        {
            new { titulo = "HAPPY HOUR TARDE (20% OFF)", descripcion = "De lunes a viernes entre 14:00 y 17:00 hrs en canchas de Fútbol 6 y Fútbol 7.", codigoPromo = "GOLAZO20" },
            new { titulo = "PACK ACADEMIAS Y ENTRENAMIENTOS (-25%)", descripcion = "Tarifa reducida en turnos de mañana (08:00 a 12:00) con conos, vallas y balones incluidos.", codigoPromo = "ENTRENA25" },
            new { titulo = "TORNEOS Y CAMPEONATOS (-15%)", descripcion = "Reserva Estadio Fútbol 11 por 2 horas e incluye mesa de control, sonido y vestuarios VIP.", codigoPromo = "COPA15" }
        }
    });
});

var port = Environment.GetEnvironmentVariable("PORT") ?? Environment.GetEnvironmentVariable("Port") ?? "10000";
app.Run($"http://0.0.0.0:{port}");

public class CanchaHorario
{
    public int Id { get; set; }
    public string Codigo { get; set; } = "";
    public string Nombre { get; set; } = "";
    public string TipoCancha { get; set; } = "";
    public string Servicio { get; set; } = "";
    public string Categoria { get; set; } = "";
    public string Fecha { get; set; } = "";
    public string Hora { get; set; } = "";
    public string Turno { get; set; } = "";
    public string Duracion { get; set; } = "";
    public string Estado { get; set; } = "";
    public bool Disponibilidad { get; set; }
    public double Precio { get; set; }
    public int Descuento { get; set; }
    public string Promocion { get; set; } = "";
    public string Capacidad { get; set; } = "";
    public string Gramado { get; set; } = "";
    public string[] ServiciosIncluidos { get; set; } = Array.Empty<string>();
    public string Imagen { get; set; } = "";
    public string Detalle { get; set; } = "";
}

public class ServicioDeportivo
{
    public int Id { get; set; }
    public string Codigo { get; set; } = "";
    public string Nombre { get; set; } = "";
    public string Categoria { get; set; } = "";
    public double Precio { get; set; }
    public string Unidad { get; set; } = "";
    public string Disponibilidad { get; set; } = "";
    public string Icono { get; set; } = "";
    public bool Destacado { get; set; }
    public string Imagen { get; set; } = "";
    public string Descripcion { get; set; } = "";
}
