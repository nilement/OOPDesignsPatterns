using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Objects.PveDecorator;

namespace hijo_del_santo.Assets
{
    enum AnimationID
    {
        Idle = 0,
        Attack,

        Count,
    }

    public class ImageLoader
    {
        private string path_start;
        private string entity;
        private string animation;
        private string file_type;
        private static ImageLoader loader = null;

        private ImageLoader()
        {
            path_start = "../../images";
            entity = "";
            animation = "";
            file_type = "png";
        }

        public static ImageLoader GetLoader()
        {
            if(loader == null)
            {
                loader = new ImageLoader();
            }

            return loader;
        }

        public void SetEntity(string _entity)
        {
            entity = _entity;
        }

        public void SetAnimation(string _animation)
        {
            animation = _animation;
        }

        public void SetType(string _type)
        {
            file_type = _type;
        }

        public Image LoadImage(int index)
        {
            return Image.FromFile(path_start + "/" + entity + "/" + animation + "/" + animation + "_" + index.ToString("D3") + "." + file_type);
        }

        public Image LoadImage(string _frame)
        {
            return Image.FromFile(path_start + "/" + entity + "/" + animation + "/" + _frame);
        }

        public Image LoadImage(string _entity, string _animation, string _frame)
        {
            return Image.FromFile(path_start + "/" + _entity + "/" + _animation + "/" + _frame);
        }
    }

    public class Animation
    {
        public bool mirror;

        public string entity;
        public string animation;
        public string type;

        public int current_frame;
        public int keyframe_delay;
        public int current_keyframe;
        public PointF center_point;
        public float scale;
        public bool is_looping;

        public Image[] keyframes;
        public RectangleF[] rectangles;

        public Animation()
        {
            mirror = false;

            entity = "knight2";
            animation = "_ATTACK";
            type = "png";

            current_frame = 0;
            keyframe_delay = 2;
            current_keyframe = 0;
            center_point = new PointF(0.0f, 0.0f);
            scale = 0.35f;
            is_looping = false;

            keyframes = new Image[7];
            ImageLoader loader = ImageLoader.GetLoader();

            loader.SetEntity(entity);
            loader.SetAnimation(animation);
            loader.SetType(type);

            for(int i = 0; i < keyframes.Length; ++i)
            {
                keyframes[i] = loader.LoadImage(i);
            }

            rectangles = new RectangleF[keyframes.Length];
            RecalculateRectangles();
        }

        public Animation(PointF _center_point, int _keyframe_delay = 2, float _scale = 1.0f, bool _is_looping = false) : this()
        {
            keyframe_delay = _keyframe_delay;
            center_point = _center_point;
            scale = _scale;
            is_looping = _is_looping;
            RecalculateRectangles();
        }

        public Animation(string _entity, string _animation, string _type, int _keyframe_delay, int _keyframe_count, PointF _center_point, bool _mirror = false, float _scale = 1.0f, bool _is_looping = false)
        {
            mirror = _mirror;

            entity = _entity;
            animation = _animation;
            type = _type;

            keyframe_delay = _keyframe_delay;
            center_point = _center_point;
            scale = _scale;
            is_looping = _is_looping;

            keyframes = new Image[_keyframe_count];
            ImageLoader loader = ImageLoader.GetLoader();

            loader.SetEntity(entity);
            loader.SetAnimation(animation);
            loader.SetType(type);

            for(int i = 0; i < keyframes.Length; ++i)
            {
                keyframes[i] = loader.LoadImage(i);

                if(mirror)
                {
                    keyframes[i].RotateFlip(RotateFlipType.RotateNoneFlipX);
                }
            }

            rectangles = new RectangleF[keyframes.Length];
            RecalculateRectangles();
        }

        private void RecalculateRectangles()
        {
            for(int i = 0; i < rectangles.Length; ++i)
            {
                SizeF size = new SizeF(keyframes[i].Size.Width * scale, keyframes[i].Size.Height * scale);
                PointF point = new PointF(center_point.X - size.Width / 2.0f, center_point.Y - size.Height / 2.0f);
                rectangles[i] = new RectangleF(point, size);
            }
        }

        public void SetDrawPoint(PointF point)
        {
            center_point = point;
            RecalculateRectangles();
        }

        public bool Render()
        {
            bool result = true;
            ++current_frame;
            if(current_frame >= keyframe_delay)
            {
                current_frame = -1;
                current_keyframe = (current_keyframe + 1) % keyframes.Length;

                if(current_keyframe == 0 && !is_looping)
                {
                    result = false;
                }
            }

            Screen.graphics.Graphics.DrawImage(keyframes[current_keyframe], rectangles[current_keyframe]);
            return result;
        }
    }

    class Entity
    {
        public int hit_points;
        public int max_hit_points;
        public HealthBar health_bar;

        public Animation idle_animation;
        public Animation attack_animation;
        public bool attack;

        public Entity() : this(100, 100, new PointF(0.0f, 0.0f), false)
        {
        }

        public Entity(int _hit_points, int _max_hit_points, PointF _start_point, bool _mirror = false)
        {
            hit_points = _hit_points;
            max_hit_points = _max_hit_points;

            idle_animation = new Animation("knight2", "_IDLE", "png", 5, 7,
                             _start_point,
                             _mirror, 0.35f, false);
            attack_animation = new Animation("knight2", "_ATTACK", "png", 2, 7,
                               _start_point,
                               _mirror, 0.35f, false);
            health_bar = new HealthBar(
                         new PointF(_start_point.X, _start_point.Y + 200),
                         hit_points, max_hit_points,
                         new Size(250, 50));
            attack = false;
        }

        public void SetHP(int hp)
        {
            if (hp < 0)
            {
                hp = 0;
            }

            hit_points = hp;
            health_bar.UpdateHitPoints(hit_points);
        }

        public void Damage(int _damage)
        {
            if(hit_points == 0)
            {
                return;
            }

            if(hit_points - _damage < 0)
            {
                hit_points = 0;
            }
            else
            {
                hit_points -= _damage;
            }

            health_bar.UpdateHitPoints(hit_points);
        }

        public void Render()
        {
            if(attack)
            {
                attack = attack_animation.Render();
            }
            else
            {
                idle_animation.Render();
            }
            health_bar.Render();
        }
    }
}
