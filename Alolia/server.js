var express = require('express');
var dm = require('./lib/mongo/datamanager').datamanager;

var app = express();

app.use(express.static(__dirname + "/wwwroot"));

app.use('/oneModule', function(req, res) {
    dm.getOneModule(function(data) {
        //res.writeHead(200);
        res.send(data);
        //res.end();
    });
});

app.use("/secondModule", function(req, res) {
    dm.getSecondModule(function(data) {
        //res.writeHead(200);
        res.send(data);
        //res.end();
    });
});

app.listen(8890);