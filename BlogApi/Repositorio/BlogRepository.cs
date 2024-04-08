using Api_blog.Context;
using AutoMapper;
using BlogApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api_blog.Repositório
{

    public interface IBlogRepository
    {
        public Task<bool> Create(PostEntitie post);
        public Task <Post> GetById(string Id);
        public Task<List<Post>> GetAllPosts();
        public Task<bool> Update(PostEntitie post, string Id);
        public bool Delete(string id);
    }

    public class BlogRepository : IBlogRepository
    {

        private readonly BloggingContext _bancocontext;
        private readonly IMapper _mapper;
        public BlogRepository(BloggingContext bancocontext, IMapper mapper)
        {
            _bancocontext = bancocontext;
            _mapper = mapper;
        }


        public static string ConvertIFormFileToBase64(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                var fileBytes = memoryStream.ToArray();
                return Convert.ToBase64String(fileBytes);
            }
        }

        public async Task<bool> Create(PostEntitie post)
        {
            try
            {
               

                var newPost = new Post()
                {
                    Title = post.Title,
                    Type = post.Type,
                    Description = post.Description,
                    Image = post.Image,
                    DescriptionImage = post.DescriptionImage
                };
                await _bancocontext.Posts.AddAsync(newPost);
                await _bancocontext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Post> GetById(string Id)
        {
            var post = await _bancocontext.Posts.FindAsync(Id);
            return post;
        }

        public async Task<List<Post>> GetAllPosts()
        {
            var posts = await _bancocontext.Posts.ToListAsync();
            return posts;
        }

        public async Task<bool> Update(PostEntitie post, string Id)
        {
            try
            {
                Post postAtual = await _bancocontext.Posts.FindAsync(Id);

                if (postAtual == null)
                {
                    return false;
                }

                postAtual = _mapper.Map<PostEntitie, Post>(post,postAtual);
       
                await _bancocontext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;

            }
        }

        public bool Delete(string id)
        {

            try
            {
                var postAtual = _bancocontext.Posts.Find(id);

                if (postAtual == null)
                {
                    return false;
                }

                _bancocontext.Remove(postAtual);
                _bancocontext.SaveChanges();
                return true;
            }
            catch
            {
                return false;

            }
        }

    }
}
