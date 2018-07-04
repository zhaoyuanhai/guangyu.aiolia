var Db = require('mongodb').Db,
    Server = require('mongodb').Server;

var server = new Server("localhost", 27017);
var db = new Db('alolia', server, {});

exports.datamanager = {
    getHomeImage: function(callback) {
        db.open(function(error, client) {
            if (error) throw error;

            var collection = db.collection("homeImage");
            collection.find().toArray(function(error, images) {
                callback(images);
                db.close();
            });
        });
    },
    getOneModule: function(callback) {

        db.open(function(error, client) {
            if (error) throw error;

            var collection = db.collection('oneModule');
            collection.find().toArray(function(error, data) {
                callback(data);
                db.close();
            });
        });
    },
    getSecondModule: function(callback) {
        db.open(function(error, client) {
            if (error) throw error;

            var collection = db.collection("secondModule");
            collection.find().toArray(function(error, data) {
                callback(data);
                db.close();
            });
        })
    },
    getThreeModule: function(callback) {
        db.open(function(error, client) {
            if (error) throw error;

            var collection = db.collection("threeModule");
            collection.find().toArray(function(error, data) {
                callback(data);
                db.close();
            })
        })
    }
};