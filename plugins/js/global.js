function ajax(pagina, fn, post) {
    $.ajax({
        url: "../" + pagina + "/" + fn,
        data: post,
        type: "POST",
        contentType: "application/json; utf-8"
    })
        .done(function (result) {
            if (typeof result !== 'string') {
                if (typeof window[fn] !== 'undefined' && typeof window[fn] === 'function')
                    window[fn](result);
            }
            else {
                console.warn(result);
                window[fn](result);
            }
        }
        ).fail(function (result) {
            alert(result.responseText);
            console.error(result.responseText)
        })
}