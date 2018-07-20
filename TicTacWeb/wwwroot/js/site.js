var ticTacToe = {        
    winner: false,
    currentPlayer: "X",

    clicked: function (whichSquare) {
        if ($("#boardPlaceholder").val() === "") {
            $("#messageTitle").html("Error");
            $('#gameResults').text("Game has not started!!");
            $('#gameModal').modal('toggle');
            return;
        }
        if (ticTacToe.winner === true) {
            $("#messageTitle").html("Error");
            $('#gameResults').text("Game has Finnished!! Please restart.");
            $('#gameModal').modal('toggle');
            return;
        }
        var boardJson = $("#boardPlaceholder").val();        
        this.play(boardJson, this.currentPlayer, parseInt(whichSquare));        
    },    

    nextPlayer: function () {
        if (this.currentPlayer === "X") {
            this.currentPlayer = "O";
        }
        else {
            this.currentPlayer = "X";
        }

        $("#playingLabel").text("It is " + this.currentPlayer + "'s turn to play.");
    },    

    clearBoard : function () {
        $('span').text('');
        this.startGame();
    },
    
    play: function (board, marker, position) {        
        var playObject = {
            gameBoard: board,

            marker: marker === "X" ? 1 : 2,
            position: position
        };                
        $.ajax({
            type: "POST",
            data: JSON.stringify(playObject),
            url: "http://localhost:50186/api/TicTacToe/Play",
            contentType: "application/json; charset=utf-8",            
            dataType: "json",            
            success: function (data) {
                // Playing = 0
                // InvalidMove = 1
                // Winner = 2
                // Tie = 3
                switch (data) {
                    case 0:
                        if (ticTacToe.currentPlayer === "X") {
                            $("." + position).text('X');
                        } else {
                            $("." + position).text('O');
                        }
                        var boardJson = $("#boardPlaceholder").val();
                        var nBoard = JSON.parse(boardJson);
                        nBoard.spaces[position] = {
                            Marker: ticTacToe.currentPlayer,
                            Number: position
                        };
                        $("#boardPlaceholder").val(JSON.stringify(nBoard));
                        ticTacToe.nextPlayer();                                                
                        break;
                    case 2:
                        if (ticTacToe.currentPlayer === "X") {
                            $("." + position).text('X');
                        } else {
                            $("." + position).text('O');
                        }
                        $("#messageTitle").html("Game Over");
                        $('#gameResults').text("Player " + ticTacToe.currentPlayer + " Wins!");
                        $('#gameModal').modal('toggle');
                        ticTacToe.winner = true;
                        $("#playingLabel").text("Game Over");
                        break;
                    case 3:
                        if (ticTacToe.currentPlayer === "X") {
                            $("." + position).text('X');
                        } else {
                            $("." + position).text('O');
                        }
                        $("#messageTitle").html("Game Over");
                        $('#gameResults').text("Its a Tie!!");
                        $('#gameModal').modal('toggle');
                        ticTacToe.winner = true;
                        $("#playingLabel").text("Game Over");
                        break;
                    case 1:
                    default:
                        $("#messageTitle").html("Error");
                        $('#gameResults').text("Invalid move!");
                        $('#gameModal').modal('toggle');
                        break;
               }
            }, //End of AJAX Success function  
            failure: function (data) {
                console.log(data.responseText);
                $("#messageTitle").html("Error");
                $('#gameResults').text(data.responseText);
                $('#gameModal').modal('toggle');
            }, //End of AJAX failure function  
            error: function (xhr, ajaxOptions, thrownError) {
                console.log(xhr.status);
                console.log(thrownError);
            } //End of AJAX error function

        });
    },

    startGame : function () {
        $.ajax({
            type: "POST",
            url: "http://localhost:50186/api/TicTacToe/StartGame",
            contentType: "application/json; charset=utf-8",
            crossDomain: true,            
            dataType: "text",
            success: function (data) {
                $("#boardPlaceholder").val(data);
                console.log("Game Started");
                this.currentPlayer = "X";
                ticTacToe.winner = false;
                $("#playingLabel").text("Game Started! It is " + this.currentPlayer + "'s turn to play.");
            }, //End of AJAX Success function  
            failure: function (data) {
                $("#messageTitle").html("Error");
                $('#gameResults').text(data.responseText);
                $('#gameModal').modal('toggle');
                alert(data.responseText);
            }, //End of AJAX failure function  
            error: function (xhr, ajaxOptions, thrownError) {
                console.log(xhr.status);
                console.log(thrownError);
            } //End of AJAX error function 

        });
    },

};