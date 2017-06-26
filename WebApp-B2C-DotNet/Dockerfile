FROM microsoft/aspnet
SHELL ["powershell", "-command"]

RUN Install-WindowsFeature NET-Framework-45-ASPNET ; \
    Install-WindowsFeature Web-Asp-Net45

RUN mkdir C:\site
COPY . C:\site

RUN Remove-WebSite -Name 'Default Web Site'
RUN New-Website -Name 'myapp' -Port 80 \
    -PhysicalPath 'C:\site' -ApplicationPool '.NET v4.5'

#RUN Powershell Remove-Item "C:\inetpub\wwwroot" -recurse


#RUN dism /online /enable-feature /all /featurename:iis-webserver /NoRestart
#RUN dism /online /enable-feature /featurename:IIS-ASPNET45


EXPOSE 80

