# Grpc-Demo
Unary and server streaming, client streaming. Pending: Biderectional, authentication, authorization

1. Create a protobuf file and then add it to the csproject. 
2. Protobuf is nothing but a contract that is not restricted to any particular language. It contains the schema of the method and class. Service maps to a controller and the method would map to an action on the controller.
3. When we build the solution, auto generated code creates the necessary code for gRPC.\
4. To add the client, right click on the project and click on manage connected services and add a link to the protobuf created by the server.
5. Pending: Test how the solution behaves when accessed concurrently 


