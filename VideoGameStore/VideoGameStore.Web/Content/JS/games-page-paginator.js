let pageNow = 1;
let maxPageCount = 1;

(function () {
    $.ajax({
        url: '/GamesPage/GetPagesCount',
        success: function (response) {
            maxPageCount = response

            setPagesHTML(1);
        },
        error: function (response) { console.log(response) }
    });
})();

function setPagesHTML(selectedPage) {
    let pagesHtml = '<a href="#" data-page="prev">&laquo;</a>';
    for (let i = 0; i < maxPageCount; ++i) {
        if (selectedPage == i + 1) {
            pagesHtml += '<a href="#" class="active" data-page="' + (i + 1) + '">' + (i + 1) + '</a>'
        } else {
            pagesHtml += '<a href="#" data-page="' + (i + 1) + '">' + (i + 1) + '</a>'
        }
    }

    pagesHtml += '<a href="#" data-page="next">&raquo;</a>';

    $('#pages').html(pagesHtml)
}

$(".games").on('click', function (ev) {
    if (ev.target.tagName.toLowerCase() === 'a') {
        let $target = $(ev.target);

        let page = $target.attr('data-page');

        if (page === 'prev') {
            pageNow--;
        }
        else if (page === 'next') {
            pageNow++;
        }
        else {
            pageNow = +page;
        }

        console.log(pageNow);

        if (pageNow < 1) {
            pageNow = 1;
        }

        if (pageNow > maxPageCount) {
            pageNow = maxPageCount;
        }

        console.log(pageNow);

        $.ajax({
            url: '/GamesPage/GetGamesOnPage?page=' + pageNow,
            success: function (response) {

                console.log(response);

                let newGameTableHTML = '<table>';
                newGameTableHTML += '<tr>';
                newGameTableHTML += '<th>Image</th>';
                newGameTableHTML += '<th>Name</th>';
                newGameTableHTML += '<th>Description</th>';
                newGameTableHTML += '<th>Price</th>';
                newGameTableHTML += '<th>Add to Cart</th>';
                newGameTableHTML += '</tr>';

                for (var i = 0; i < response.games.length; i++) {
                    newGameTableHTML += '<tr>';
                    newGameTableHTML += '<td><img class="game-img" src="' + response.games[i].ImageUrl + '" alt="game img" /></td>';
                    newGameTableHTML += '<td class="name"><h3><a class="" href="/gameinfo/' + response.games[i].Id + '">' + response.games[i].Name + '</a></h3></td>';
                    newGameTableHTML += '<td><p>' + response.games[i].Description + '</p></td>';
                    newGameTableHTML += '<td><h3>$' + response.games[i].Price.toFixed(2) + '</h3></td>';
                    if (response.isAuthenticated) {
                        newGameTableHTML += '<td><form action="/GamesPage/AddToCart?gameId=' + response.games[i].Id + '" method="post"><button type="submit" class="btn btn-success add">Add to Cart</button></form></td>';
                    }
                    newGameTableHTML += '</tr>';
                }

                newGameTableHTML += '</table>';

                newGameTableHTML += '<div class="pagination" id="pages"></div>'

                $('.games').html(newGameTableHTML);

                setPagesHTML(pageNow);
            },
            error: function (response) { console.log(response) }
        });
    }
});