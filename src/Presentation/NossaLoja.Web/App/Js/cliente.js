async function clienteIndex() {
    await renderHtmlAsync("#main", "/App/Html/Cliente/index.html");

    const { data } = await clienteApiGetAll();

    clienteIndexLoadTable(data.Clientes);
}

function clienteIndexLoadTable(clientes) {
    if (!clientes)
        return;

    $("#ClientesTable tbody").html('');

    let rows = '';

    for (var i = 0; i < clientes.length; i++) {

        let cliente = clientes[i];

        const descricao = `${cliente.Nome} | ${cliente.Id}`;
        const cpfCnpj = cliente.Cpf ? cliente.Cpf : cliente.Cnpj;

        rows += `
            <tr id="${cliente.Id}" class="row" ondblclick="clienteOnDblClick(this)">
                <td hidden="hidden">
                    <input type="checkbox" />
                </td>
                <td class="col text-left">
                    <p class="font-bold">
                        ${descricao}
                    </p>
                </td>
                <td class="col-3 text-left">
                    <p class="font-book">
                        ${cpfCnpj}
                    </p>
                </td>
            </tr>
        `;
    }

    $("#ClientesTable tbody").html(rows);
}

function clienteOnDblClick(el) {
    $(el).find("td").first().find("input").prop("checked", true);

    clienteEdit();
}

async function clienteEdit() {
    const _linhasSelecionadas = linhasSelecionadas('#ClientesTable');

    if (_linhasSelecionadas.length == 0) {
        alert("Deve-se selecionar um cliente", "warning");
        return;
    }

    if (_linhasSelecionadas.length > 1) {
        alert("Deve-se selecionar apenas um cliente", "warning");
        return;
    }

    const clienteId = _linhasSelecionadas[0];

    if (clienteId == 0) {
        alert("O código do cliente é inválido.", "warning")
        return;
    }

    await renderHtmlAsync("#main", "/App/Html/Cliente/Form.html");

    clienteFormLoad(clienteId);
}

async function clienteFormLoad(clienteId) {
    const response = await clienteApiGet(clienteId);

    const cliente = response.data;

    $("#Codigo").val(cliente.Id);
    $("#Nome").val(cliente.Nome);
    $("#Cpf").val(cliente.Cpf);
    $("#Identidade").val(cliente.Identidade);
    $("#Cnpj").val(cliente.Cnpj);
    $("#InscricaoEstadual").val(cliente.InscricaoEstadual);
}

function clienteApiGetAll() {
    return axios({
        method: "GET",
        url: `${NossaLoja_WS()}/Api/Clientes`
    });
}

function clienteApiGet(clienteId) {
    return axios({
        method: "GET",
        url: `${NossaLoja_WS()}/Api/Clientes/${clienteId}`
    });
}