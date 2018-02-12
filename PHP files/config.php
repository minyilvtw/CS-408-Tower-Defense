<?php
define('DB_SERVER', 'localhost');
define('DB_USERNAME', 'id4716430_cs408dev');
define('DB_PASSWORD', 'Purdue2018');
define('DB_NAME', 'id4716430_users');

/* Attempt to connect to MySQL database */
$link = mysqli_connect(DB_SERVER, DB_USERNAME, DB_PASSWORD, DB_NAME);

if($link === false){
    die("ERROR: Could not connect. " . mysqli_connect_error());
}
?>