async function loadHome() {
    console.log("Carregou a tela inicial");

    await renderHtmlAsync("#main", "/App/Html/Core/Home/index.html");
}