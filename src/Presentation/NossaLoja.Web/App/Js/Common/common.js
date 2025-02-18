async function loadHome() {
    await renderHtmlAsync("#main", "/App/Html/Core/Home/index.html");
}

function linhasSelecionadas(element) {
    var linhas = new Array();

    $(element).find('tr').each(function () {
        if ($(this).find('input[type="checkbox"]').is(':checked')) {
            linhas.push(this.id);
        }
    });

    return (linhas)
}