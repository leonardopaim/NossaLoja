async function clienteIndex() {
    await renderHtmlAsync("#main", "/App/Html/Cliente/index.html");
}

function clienteApiGetAll() {
    return axios({
        method: "GET",
        url: `${NossaLoja_WS()}/Api/Clientes`
    });
}