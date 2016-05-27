<?php
header("Content-type: text/html; charset=utf-8");
/**
* ip 工具类
*/
class IpTool
{
    
    function __construct()
    {
        
    }
    
    function trim_aliIP($addr)
    {
        if(preg_match("/121.42./i",$addr ))
        {
            die("access deny!");
        }
    }

    function getIP(){
        global $ip;
        if (getenv("HTTP_CLIENT_IP"))
        {
            $ip = getenv("HTTP_CLIENT_IP");
        }
        else if(getenv("HTTP_X_FORWARDED_FOR"))
            {
                $ip = getenv("HTTP_X_FORWARDED_FOR");
            }
        else if(getenv("REMOTE_ADDR"))
            {
                $ip = getenv("REMOTE_ADDR");
            }
        else 
        {
            $ip = "Unknow";
        }
        //防止阿里云端口扫描
        $this->trim_aliIP($ip)
        return $ip;
    }

}
$iptool = new IpTool();
$operation = isset($_GET['operation'])?$_GET['operation']:"";
$addr = $iptool->getIP();

if($operation === "set")
{
    $mysqli = new mysqli('localhost','root','a4d89f2ced','FPS');
    if (mysqli_connect_errno())
    {
	//注意mysqli_connect_error()新特性
	die('Unable to connect!'). mysqli_connect_error();
    } 
    //  var_dump($mysqli);
    $score = $_GET['score'];
    $sql = "insert into score (score,ip) value( '".$score."' , '".$addr."')";
    $result = $mysqli->query($sql);
    
}elseif($operation === "get")
{
    $mysqli = new mysqli('localhost','root','a4d89f2ced','FPS');
     if (mysqli_connect_errno())
    {
        //注意mysqli_connect_error()新特性
        die('Unable to connect!'). mysqli_connect_error();
    }
    $sql = "select max(score)as h_score from score where ip = '".$addr."'";
    $result = $mysqli->query($sql);
   // die(var_dump($result));
    while($row = $result->fetch_array())
    {
        echo $row['h_score'];
        die();
    }
}
?>
