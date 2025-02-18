function _switch(element, callback) {
    let checked = $(element).find('input:checkbox').is(':checked');
    $(element).find('input:checkbox').prop('checked', !checked);

    callback && eval(callback);
}