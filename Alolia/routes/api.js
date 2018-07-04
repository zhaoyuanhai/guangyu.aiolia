var express = require('express');
var router = express.Router();
var dm = require('../lib/mongo/datamanager').datamanager;

router.get('/homeImage', function(req, res) {
    dm.getHomeImage(function(data) {
        res.writeHead(200);
        res.write(JSON.stringify(data));
        res.end();
    });
});

router.get('/oneModule', function(req, res) {
    dm.getOneModule(function(data) {
        res.writeHead(200);
        res.write(JSON.stringify(data));
        res.end();
    });
});

router.get("/secondModule", function(req, res) {
    dm.getSecondModule(function(data) {
        res.writeHead(200);
        res.write(JSON.stringify(data));
        res.end();
    });
});

router.get('/threeModule', function(req, res) {
    dm.getThreeModule(function(data) {
        res.writeHead(200);
        res.write(JSON.stringify(data));
        res.end();
    });
});

module.exports = router;