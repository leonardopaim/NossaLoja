async function renderHtmlAsync(parent, content) {
    const res = await axios({
        method: "get",
        url: content
    });

    $(parent).html(res.data);
}