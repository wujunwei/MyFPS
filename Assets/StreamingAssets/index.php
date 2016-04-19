<?php
//phpinfo();
// xhprof_enable(XHPROF_FLAGS_CPU | XHPROF_FLAGS_MEMORY);
// // run program

//  $url = "https://graph.facebook.com/100011347343975/picture?width=100&height=100";

// $ch = curl_init();
//     curl_setopt($ch,  CURLOPT_RETURNTRANSFER, 1);
//     curl_setopt($ch, CURLOPT_URL,  $url);
//     curl_setopt($ch, CURLOPT_CONNECTTIMEOUT, 30);
//     curl_setopt($ch, CURLOPT_TIMEOUT, 30);
//     curl_setopt($ch, CURLOPT_POST, 1);
//     curl_setopt($ch, CURLOPT_NOBODY, 1);
//     curl_setopt($ch, CURLOPT_HEADER, 1);
//     curl_setopt($ch,  CURLOPT_FOLLOWLOCATION, 1); // 获取转向后的内容          
//     $data = curl_exec($ch);
//     $Headers =  curl_getinfo($ch);       
//     curl_close($ch);
//     echo $Headers["url"];
//     echo $data;    

// phpinfo();
// $xhprof_data = xhprof_disable();
// var_dump($xhprof_data);
?>
<html>
<body style="background-image:;background-position:center; background-repeat:repeat-y;background-color:rgb(137, 207, 240);">
<head>
<title>加密</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<?php
    $map = array();
    for ($j= -42; $j < 42; $j++) {  
        for ($i = -48; $i < 48; $i++) {
            if($i <= 4&&$i >= -30)
            {
                if(($j <= 24&&$j >= 10)||($j <= -14&&$j >=-28))
                {
                    $map[$j][$i] = 1;
                }else
                {
                    $map[$j][$i] = 0;
                }
            }else
            {
                $map[$j][$i] = 0;
            }
            
        }
    }



     for ($j= -42; $j < 42; $j++) {
        for ($i= -48; $i < 48; $i++) {

            echo $map[$j][$i];
        }
        echo "\n";
    }

?>

</body>
</html>