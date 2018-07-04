var express = require('express');
var router = express.Router();

/* GET users listing. */
router.get('/', function(req, res, next) {
    res.send('respond with a resource');
});

router.get('/api/a', function(req, res) {
    res.send('asfldjsa;fje');
})

module.exports = router;