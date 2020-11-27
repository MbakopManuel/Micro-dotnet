#!/bin/bash

SAMPLEDIR="Sample.Microservice"
SAMPLENAME="Sample"
SAMPLENAMEMIN="Sample"

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
    name=$1
    echo "folders creation ..."
    #creation de l'opération
    cp -r "$OPDIR/Samples" "$OPDIR/${name}Operation"
    echo "$OPDIR/${name}Operation created"
    
    #create service
    cp -r "$SEDIR/Samples" "$SEDIR/${name}Service"
    echo "$SEDIR/${name}Service created"
    
    #create repository
    cp -r "$REDIR/Samples" "$REDIR/${name}Repository"
    echo "$REDIR/${name}Repository created"

}

delete_folders(){
    name=$1
    echo "folders deletion ..."
    #creation de l'opération
    rm -r "$OPDIR/${name}Operation"
    echo "$OPDIR/${name}Operation deleted"

   
    
    #create service
    rm -r "$SEDIR/${name}Service"
    echo "$SEDIR/${name}Service deleted"

    
    #create repository
    rm -r "$REDIR/${name}Repository"
    echo "$REDIR/${name}Repository deleted"


    echo "folders deleted"
}

#renommage des differents dossiers créés
rename_folders(){

    name=$1
    lowerName=${name,,}
    lowerName=${lowerName%?}
    echo "renaming..."

    #rename des opérations
    dotnet run -p ./RenameUtility/RenameUtility -- "$OPDIR/${name}Operation" "Movie" ${name%?}
    dotnet run -p ./RenameUtility/RenameUtility -- "$OPDIR/${name}Operation" "movie" $lowerName

    #rename des services
    dotnet run -p ./RenameUtility/RenameUtility -- "$SEDIR/${name}Service" "Movie" ${name%?}
    dotnet run -p ./RenameUtility/RenameUtility -- "$SEDIR/${name}Service" "movie" $lowerName

    #rename des repositories
    dotnet run -p ./RenameUtility/RenameUtility -- "$REDIR/${name}Repository" "Movie" ${name%?}
    dotnet run -p ./RenameUtility/RenameUtility -- "$REDIR/${name}Repository" "movie" $lowerName
	echo "end."
}


main(){
    #creation du dossier de projet
    create_folders $1
    #renommage des différents elements
    rename_folders $1
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
	add)
	    main $2

        build_project
	    ;;
	delete)
	    delete_folders $2
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
                add [PROJECT_Name] \n
                delete [FOLDER_NAME] \n
                rename [OLD_NAME] [NEW_NAME] \n
                rename-in [PROJECT_NAME] [OLD_NAME] [NEW_NAME]"
	    ;;
   esac
		   
else
    echo "il faut deux parametre obligatoire: COMMAND(add, delete, rename-in)"
fi

