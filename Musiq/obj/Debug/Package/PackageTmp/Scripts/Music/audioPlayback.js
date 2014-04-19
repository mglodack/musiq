var socket;

$(document).ready(function () {

    var audio;
    var remotePlaylist;
    var playlist;
    var tracks;
    var current;
    var currentSong = $('#current-song');
    var by = $('#by_span');
    var currentArtist = $('#current-artist');
    var startIndex;
    var len;
    var link;

    var shuffledArray;
    var shuffle;
    var newShuffle;

    function init() {
        current = 0;
        audio = $('#audio');
        playlist = $('#music-playlist');
        tracks = playlist.find('tbody tr');
        len = tracks.length;

        shuffledArray = tracks.slice(0);
        shuffle = false;

        $('#btn-shuffle').click(function (e) {
            if (shuffle == false) {
                shuffle = true;
                newShuffle = shuffleArray(shuffledArray);
            } else {
                shuffle = false;
                current = tracks.index(newShuffle[current]);
            }
        });
        playlist.find('tbody tr').click(function (e) {
            e.preventDefault();
            if (/Android|webOS|iPhone|iPad|iPod|Blackberry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {
                link = $(this);

                current = (link.index());
                run($(link), audio[0]);
            }
            else {
                if (e.ctrlKey) {
                    if ($(this).hasClass('active-link')) {
                        $(this).removeClass('active-link');
                    } else {
                        $(this).addClass('active-link');
                    }
                } else {
                    if (e.shiftKey) {
                        var endIndex = $(this).index() + 1;
                        var items;
                        if (startIndex < endIndex) {
                            items = tracks.slice(startIndex, endIndex);
                        } else {
                            items = tracks.slice(endIndex - 1, startIndex);
                        }
                        $.each(items, function (index, value) {
                            $(value).addClass('active-link');
                        });
                    } else {
                        $(this).addClass('active-link').siblings().removeClass('active-link');
                    }
                }
                startIndex = $(this).index();
            }

        });


        playlist.find('tbody tr').dblclick(function (e) {
            e.preventDefault();
            link = $(this);

            current = (link.index());
            run($(link), audio[0]);
        });

        socket = io.connect("ec2-54-186-63-97.us-west-2.compute.amazonaws.com:9123");
        socket.on('connect', function () {
            socket.on('message', function (msg) {
                console.log(msg);
                var command = JSON.parse(msg);
                // This is where the magic is!
                var song = $(playlist.find("[data-songid='" + command.id + "']"));
                $(song).trigger('dblclick');

            });
        });

        remotePlaylist = $('#remote-playlist');
        remotePlaylist.find('tbody tr').dblclick(function (e) {
            console.log("double click");
            e.preventDefault();

            var command = {
                id: $(this).data('songid'),
                action: "dblclick"
            };

            socket.send(JSON.stringify(command));
        });

    }
    //End init

    init();

    function shuffleArray(o) { //v1.0
        for (var j, x, i = o.length; i; j = Math.floor(Math.random() * i), x = o[--i], o[i] = o[j], o[j] = x);
        return o;
    }
    function isElementVisible(elementToBeChecked) {
        var TopView = $(window).scrollTop() + 60;
        var BotView = TopView + $(window).height() - 120;
        var TopElement = $(elementToBeChecked).offset().top;
        var BotElement = TopElement + $(elementToBeChecked).height();
        return ((BotElement <= BotView) && (TopElement >= TopView));
    }
    function previousSong() {
        if (!shuffle) {
            current = current - 1;
            if (current < 0) {
                current = len;
                link = playlist.find('tbody tr')[current];
            } else {
                link = playlist.find('tbody tr')[current];
            }
        }
        else {
            current = current - 1;
            if (current < 0) {
                current = len;
                link = newShuffle[current];
            }
            else {
                link = newShuffle[current];
            }
        }
        run($(link), audio[0]);
    }

    function nextSong() {
        if (!shuffle) {
            current = current + 1;
            if (current == len) {
                current = 0;
                link = playlist.find('tbody tr')[0];
            } else {
                link = playlist.find('tbody tr')[current];
            }
        } else {
            current = current + 1;
            if (current == len) {
                current = 0;
                link = newShuffle[current];
            }
            else {
                link = newShuffle[current];
            }
        }
        run($(link), audio[0]);
    }

    function activateListeners(event) {
        var char = event.which;

        //If space or pause/play button is pressed, play or pause music
        if (char == 32 || char == 179) {
            toggleMusic();
        }

        //If left arrow or rewind button is pressed, go back one song
        if (char == 37 || char == 177) {
            previousSong();
        }

        //If right arrow is fast-forward button pressed, go forward one song
        if (char == 39 || char == 176) {
            nextSong();
        }
    }

    audio[0].addEventListener('ended', function (e) {
        var songId = currentSong.attr('data-songid');
        nextSong();
        $.ajax({
            url: "/Music/IncrementPlays",
            data: { SongId: songId },
            success: function (data) {
            }
        });
    });

    function run(link, player) {
        player.src = $(link).attr('data-songlink');
        selectedRow = $(link);
        selectedRow.addClass('active-link').siblings().removeClass('active-link');
        audio[0].load();
        audio[0].play();
        var songId = selectedRow.data('songid');
        var song = selectedRow.data('song');
        $(currentSong).attr('data-songid', songId);
        var artist = selectedRow.data('artist');
        console.log(selectedRow);

        if (!isElementVisible(selectedRow)) {
            $('html body').animate({
                scrollTop: selectedRow.position().top
            }, 500);
        }


        currentSong.text(song);
        by.show();
        currentArtist.text(artist);
        if (!isElementVisible(selectedRow)) {
            //$(window).scrollTop(selectedRow.position().top);
            // $(window).animate({ scrollTop: selectedRow.position().top, duration: 'slow', easing: 'swing' });
            $('html body').animate({
                scrollTop: selectedRow.position().top
            }, 500);
        }
    }

    //Scroll To Song
    function isElementVisible(elementToBeChecked) {
        var TopView = $(window).scrollTop() + 60;
        var BotView = TopView + $(window).height() - 120;
        var TopElement = $(elementToBeChecked).offset().top;
        var BotElement = TopElement + $(elementToBeChecked).height();
        return ((BotElement <= BotView) && (TopElement >= TopView));
    }


    $('.list-group-item').click(function (e) {
        var username = $('#current-username').val();
        var playlistId = parseInt($(this).attr('data-playlistid'));
        var playlistName = $(this).attr('data-playlistname');
        $.ajax({
            url: "/Playlist/Change",
            data: { Username: username, PlaylistId: playlistId, PlaylistName: playlistName },
            success: function (data) {
                $('#music-playlist').html(data);
                init();
            }
        });
    });
});