#!/bin/bash

SAMPLEDIR="Sample.Microservice"
SAMPLENAME="Sample"
SAMPLENAMEMIN="Sample"
OPDIR="Operations"
SEDIR="Services"
REDIR="Repositories"

#create project
create_project(){
    name=$1
    echo "project creation ..."
    cp -r "$SAMPLEDIR" "$name.Microservice"
    echo "project created ..."
}

#renommer le projet
rename_project(){
    name=$1
    lowerName=${name,,}
    dotnet run -p ./RenameUtility/RenameUtility -- $name $SAMPLENAME $name
    dotnet run -p ./RenameUtility/RenameUtility -- $name $SAMPLENAME $lowerName
}

#suppression d'un projet
delete_project(){
    name=$1
    rm -r "${name}.Microservice"
    remove_in_solution $name
}


#creation des differents dossiers du service
create_folders(){
    name=$2
    projet=$1
    echo "folders creation ..."
    #creation de l'opération
    cp -r "$projet.Microservice/$OPDIR/Samples" "$projet.Microservice/$OPDIR/${name}"
    echo "$projet.Microservice/$OPDIR/${name} created"
    
    #create service
    cp -r "$projet.Microservice/$SEDIR/Samples" "$projet.Microservice/$SEDIR/${name}"
    echo "$projet.Microservice/$SEDIR/${name} created"
    
    #create repository
    cp -r "$projet.Microservice/$REDIR/Samples" "$projet.Microservice/$REDIR/${name}"
    echo "$projet.Microservice/$REDIR/${name}Repository created"

}

delete_folders(){
    projet=$1
    name=$2

    echo "folders deletion ..."
    #creation de l'opération
    rm -r "$projet.Microservice/$OPDIR/${name}"
    echo "$projet.Microservice/$OPDIR/${name} deleted"

   
    
    #create service
    rm -r "$projet.Microservice/$SEDIR/${name}"
    echo "$projet.Microservice/$SEDIR/${name} deleted"

    
    #create repository
    rm -r "$projet.Microservice/$REDIR/${name}"
    echo "$projet.Microservice/$REDIR/${name} deleted"


    echo "folders deleted"
}

#renommage des differents dossiers créés
rename_folders(){
    projet=$1
    name=$2
    lowerName=${name,,}
    lowerName=${lowerName%?}
    echo "renaming..."
    #rename des opérations
    dotnet run -p ./RenameUtility/RenameUtility -- "$projet.Microservice/$OPDIR/${name}" "Sample" ${name%?}
    dotnet run -p ./RenameUtility/RenameUtility -- "$projet.Microservice/$OPDIR/${name}" "Sample" $lowerName

    #rename des services
    dotnet run -p ./RenameUtility/RenameUtility -- "$projet.Microservice/$SEDIR/${name}" "Sample" ${name%?}
    dotnet run -p ./RenameUtility/RenameUtility -- "$projet.Microservice/$SEDIR/${name}" "sample" $lowerName

    #rename des repositories
    dotnet run -p ./RenameUtility/RenameUtility -- "$projet.Microservice/$REDIR/${name}" "Sample" ${name%?}
    dotnet run -p ./RenameUtility/RenameUtility -- "$projet.Microservice/$REDIR/${name}" "sample" $lowerName
	echo "end."
}


main(){
    #creation du dossier de projet
    create_folders $1 $2
    #renommage des différents elements
    rename_folders $1 $2
}

main_project(){
    #create project
    create_project $1 
    #renommage du projet
    rename_project $1
    #ajouter un projet à la solution
    add_in_solution $1
    #build projet
    build_project
}

build_project(){
    dotnet build Microservice.WebApi.sln
}

add_in_solution(){
    dotnet sln add "${1}.Microservice/${1}.Microservice.csproj"
}

remove_in_solution(){
    dotnet sln remove "${1}.Microservice/${1}.Microservice.csproj"
}



#run du projet
if [ $# -ge 2 ]
then
    case $1 in
	add-service)
        # echo "$2.Microservice/$OPDIR $3"
	    main $2 $3
	    ;;
	delete-service)
	    delete_folders $2 $3
	    ;;
	add-project)
	    main_project $2
	    ;;
	delete-project)
	    delete_project $2
	    ;;
    rename)
        echo "$2 $3"
	    dotnet run -p ./RenameUtility/RenameUtility -- "./" $2 $3

        echo "${2,,} ${3,,}"
	    dotnet run -p ./RenameUtility/RenameUtility -- "./" ${2,,} ${3,,}
     
        build_project
	    ;;
    rename-in)
        echo "$2 $3 $4"
	    dotnet run -p ./RenameUtility/RenameUtility -- $2 $3 $4

        echo "$2 ${3,,} ${4,,}"
	    dotnet run -p ./RenameUtility/RenameUtility -- $2 ${3,,} ${4,,}
     
        build_project
	    ;;
    echo)
        echo "${2}.Microservice/${2}.Microservice.csproj"
        ;;
	*)
	    echo "run <COMMAND> : \n 
                add [PROJECT_NAME] [SERVICE_NAME] \n
                delete [FOLDER_NAME] \n
                rename [OLD_NAME] [NEW_NAME] \n
                rename-in [PROJECT_NAME] [OLD_NAME] [NEW_NAME]"
	    ;;
   esac
		   
else
    echo "il faut deux parametre obligatoire: COMMAND(add, delete, rename-in)"
fi

