cd c:\
set path=C:\Program Files/java/jdk1.8.0_74/bin

cd C:\GenericEncryption_Client\GenericEncryption_Client\
TITLE ENCDAEMON
set classpath=C:\GenericEncryption_Client/GenericEncryption_Client/jars/log4j-1.2.8.jar;C:\GenericEncryption_Client/GenericEncryption_Client/jars/encrypt.jar;C:\GenericEncryption_Client/GenericEncryption_Client/jars/enetcore.jar;C:\GenericEncryption_Client/GenericEncryption_Client/jars/jce1_2_2.jar;C:\GenericEncryption_Client/GenericEncryption_Client/jars/sunjce_provider.jar;C:\GenericEncryption_Client/GenericEncryption_Client/jars/local_policy.jar;C:\GenericEncryption_Client/GenericEncryption_Client/jars/commons-codec-1.3.jar;

java enet.encrypt.encryptionDaemon