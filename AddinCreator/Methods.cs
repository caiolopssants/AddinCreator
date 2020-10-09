using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddinCreator
{
    static class Methods
    {
        internal static List<string> CreatCommandAddinDoc(string addinTitle, string addinDescription, string assemblyPath, string fullClassName, Guid clientID, string vendorID, string vendorDescription)
        {
            return new List<string>()
            {
                $@"<?xml version={"\""}1.0{"\""} encoding={"\""}utf-8{"\""}?>",
                $@"<RevitAddIns>",
                $@"  <AddIn Type={"\""}Command{"\""}>",
                $@"    <Text>{addinTitle}</Text>",
                $@"    <Description>{addinDescription}</Description>",
                $@"    <Assembly>{assemblyPath}</Assembly>",
                $@"    <FullClassName>{fullClassName}</FullClassName>",
                $@"    <ClientId>{clientID}</ClientId>",
                $@"    <VendorId>{vendorID}</VendorId>",//$@"    <VendorId>br.com.mha</VendorId>",
                $@"    <VendorDescription>{vendorDescription}</VendorDescription>",//$@"    <VendorDescription>MHA Engenharia LTDA</VendorDescription>",
                $@"  </AddIn>",
                $@"</RevitAddIns>",
            };
        }

        internal static List<string> CreatApplicationAddinDoc(string addinTitle, string assemblyPath, string fullClassName, Guid clientID, string vendorID, string vendorDescription)
        {
            return new List<string>()
            {
                $@"<?xml version={"\""}1.0{"\""} encoding={"\""}utf-8{"\""}?>",
                $@"<RevitAddIns>",
                $@"  <AddIn Type={"\""}Application{"\""}>",
                $@"    <Name>App {addinTitle}</Name>",
                $@"    <Assembly>{assemblyPath}</Assembly>",
                $@"    <FullClassName>{fullClassName}</FullClassName>",
                $@"    <ClientId>{clientID}</ClientId>",
                $@"    <VendorId>{vendorID}</VendorId>",//$@"    <VendorId>br.com.mha</VendorId>",
                $@"    <VendorDescription>{vendorDescription}</VendorDescription>",//$@"    <VendorDescription>MHA Engenharia LTDA</VendorDescription>",
                $@"  </AddIn>",
                $@"</RevitAddIns>",
            };
        }

        internal static List<string> CreatCommandApplicationAddinDoc(string addinTitle_Command, string addinDescription_Command, string assemblyPath_Command, string fullClassName_Command, Guid clientID_Command, string vendorID_Command, string vendorDescription_Command, string addinTitle_Application, string assemblyPath_Application, string fullClassName_Application, Guid clientID_Application, string vendorID_Application, string vendorDescription_Application)
        {
            return new List<string>()
            {
                   $@"<?xml version={"\""}1.0{"\""} encoding={"\""}utf-8{"\""}?>",
                $@"<RevitAddIns>",
                $@"  <AddIn Type={"\""}Command{"\""}>",
                $@"    <Text>{addinTitle_Command}</Text>",
                $@"    <Description>{addinDescription_Command}</Description>",
                $@"    <Assembly>{assemblyPath_Command}</Assembly>",
                $@"    <FullClassName>{fullClassName_Command}</FullClassName>",
                $@"    <ClientId>{clientID_Command}</ClientId>",
                $@"    <VendorId>{vendorID_Command}</VendorId>",//$@"    <VendorId>br.com.mha</VendorId>",
                $@"    <VendorDescription>{vendorDescription_Command}</VendorDescription>",//$@"    <VendorDescription>MHA Engenharia LTDA</VendorDescription>",
                $@"  </AddIn>",
                $@"  <AddIn Type={"\""}Application{"\""}>",
                $@"    <Name>{addinTitle_Application}</Name>",
                $@"    <Assembly>{assemblyPath_Application}</Assembly>",
                $@"    <FullClassName>{fullClassName_Application}</FullClassName>",
                $@"    <ClientId>{clientID_Application}</ClientId>",
                $@"    <VendorId>{vendorID_Application}</VendorId>",//$@"    <VendorId>br.com.mha</VendorId>",
                $@"    <VendorDescription>{vendorDescription_Application}</VendorDescription>",//$@"    <VendorDescription>MHA Engenharia LTDA</VendorDescription>",
                $@"  </AddIn>",
                $@"</RevitAddIns>",
            };
        }
    }
}
